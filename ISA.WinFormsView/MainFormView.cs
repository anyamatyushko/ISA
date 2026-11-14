using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ISA.Shared;


namespace ISA.WinFormsView
{
    public partial class MainFormView : Form, IView
    {
        // Кэш текущих машин на экране (нужен для локальной сортировки и предзаполнения окна редактирования)
        private List<CarDto> _currentCars = new List<CarDto>();

        public event Action? OnLoadAllCars;
        public event Action<CarBrandDto, decimal>? OnCreateCar;
        public event Action<int, CarBrandDto, decimal>? OnUpdateCar;
        public event Action<int>? OnDeleteCar;
        public event Action<decimal>? OnFilterByBudget;
        public event Action? OnGroupByBrand;

        public MainFormView()
        {
            InitializeComponent();
        }

        private void MainFormView_Load(object sender, EventArgs e)
        {
            InitTable();
            OnLoadAllCars?.Invoke();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            OnLoadAllCars?.Invoke();
        }

        /// <summary>
        /// Выполняет первичную настройку колонок и режима выделения таблицы.
        /// </summary>
        private void InitTable()
        {
            dgvCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        /// <summary>
        /// Отображает переданный список автомобилей в таблице.
        /// </summary>
        public void DisplayCars(List<CarDto> cars)
        {
            _currentCars = cars;

            dgvCars.DataSource = null;
            dgvCars.Columns.Clear();
            dgvCars.DataSource = _currentCars;
        }

        /// <summary>
        /// Отрисовывает сгруппированный по брендам список автомобилей с серыми заголовками групп.
        /// </summary>
        public void DisplayGroupedCars(Dictionary<CarBrandDto, List<CarDto>> groupedData)
        {
            if (groupedData.Count == 0)
            {
                MessageBox.Show("Список автомобилей пуст. Нечего группировать.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvCars.DataSource = null;
            dgvCars.Columns.Clear();
            dgvCars.Columns.Add("Id", "ID");
            dgvCars.Columns.Add("Brand", "Бренд");
            dgvCars.Columns.Add("Price", "Цена");
            dgvCars.Rows.Clear();

            foreach (KeyValuePair<CarBrandDto, List<CarDto>> pair in groupedData)
            {
                CarBrandDto brand = pair.Key;
                List<CarDto> carsInGroup = pair.Value;

                int headerIndex = dgvCars.Rows.Add();
                dgvCars.Rows[headerIndex].Cells[0].Value = $"*Группа: {brand} (Количество: {carsInGroup.Count})";

                dgvCars.Rows[headerIndex].DefaultCellStyle.Font = new Font(dgvCars.Font, FontStyle.Bold);
                dgvCars.Rows[headerIndex].DefaultCellStyle.BackColor = Color.LightGray;
                dgvCars.Rows[headerIndex].ReadOnly = true;

                foreach (CarDto car in carsInGroup)
                {
                    string indentedBrand = "    " + car.Brand.ToString();
                    dgvCars.Rows.Add(car.Id, indentedBrand, car.Price.ToString("C"));
                }
            }
        }

        /// <summary>
        /// Выводит всплывающее окно с сообщением от Презентера или Модели.
        /// </summary>
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void AddButton_Click(object sender, EventArgs e)
        {
            // Дочерняя форма теперь работает как BudgetFormView: не принимает логику, а возвращает свойства
            AddBrandFormView addBrandFormView = new AddBrandFormView();

            if (addBrandFormView.ShowDialog() == DialogResult.OK)
            {
                OnCreateCar?.Invoke(addBrandFormView.SelectedBrand, addBrandFormView.EnteredPrice);
                OnLoadAllCars?.Invoke(); // Запрашиваем обновленный список для таблицы
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (dgvCars.SelectedRows.Count > 0 && dgvCars.SelectedRows[0].Cells[0].Value != null)
            {
                // Защита от клика по серому заголовку группы
                if (!int.TryParse(dgvCars.SelectedRows[0].Cells[0].Value.ToString(), out int selectedId))
                {
                    ShowMessage("Пожалуйста, выберите строку с конкретным автомобилем, а не заголовок группы.");
                    return;
                }

                var selectedCar = _currentCars.FirstOrDefault(c => c.Id == selectedId);
                if (selectedCar == null) return;

                // Передаем в окно редактирования только DTO-данные для предзаполнения полей
                UpdateBrandFormView updateBrandFormView = new UpdateBrandFormView(selectedCar.Brand, selectedCar.Price);

                if (updateBrandFormView.ShowDialog() == DialogResult.OK)
                {
                    OnUpdateCar?.Invoke(selectedId, updateBrandFormView.SelectedBrand, updateBrandFormView.EnteredPrice);
                    OnLoadAllCars?.Invoke();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выделите в таблице строку с автомобилем, который хотите обновить.",
                                "Выбор не сделан", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BudgetButton_Click(object sender, EventArgs e)
        {
            BudgetFormView budgetFormView = new BudgetFormView();

            if (budgetFormView.ShowDialog() == DialogResult.OK)
            {
                decimal maxBudget = budgetFormView.EnteredBudget;
                OnFilterByBudget?.Invoke(maxBudget);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dgvCars.SelectedRows.Count > 0 && dgvCars.SelectedRows[0].Cells[0].Value != null)
            {
                if (!int.TryParse(dgvCars.SelectedRows[0].Cells[0].Value.ToString(), out int selectedId))
                {
                    ShowMessage("Выберите строку с конкретным автомобилем.");
                    return;
                }

                OnDeleteCar?.Invoke(selectedId);
                OnLoadAllCars?.Invoke();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выделите строку для удаления.", "Выбор не сделан", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SortByBrandButton_Click(object sender, EventArgs e)
        {
            if (_currentCars.Count == 0)
            {
                MessageBox.Show("Список автомобилей пуст. Нечего сортировать.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var sortedCars = _currentCars.OrderBy(car => car.Brand.ToString()).ToList();

            dgvCars.DataSource = null;
            dgvCars.DataSource = sortedCars;
        }

        private void GroupByBrandButton_Click(object sender, EventArgs e)
        {
            OnGroupByBrand?.Invoke();
        }

        private void ResetFilterButton_Click(object sender, EventArgs e)
        {
            OnLoadAllCars?.Invoke();
        }


    }
}
