using ISA.BusinessLogic;
using ISA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ISA.WinFormsView
{
    public partial class MainFormView : Form
    {

        private readonly Logic _logic;

        public MainFormView(Logic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvCars.DataSource = _logic.GetAll();
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
        /// Обновляет строки таблицы на основе данных из бизнес-логики.
        /// </summary>
        /// <param name="maxPrice">Максимально допустимая цена автомобиля для фильтрации.</param>
        private void UpdateTable(decimal? maxPrice = null)
        {
            List<Car> carsToShow;

            if (maxPrice.HasValue)
            {
                carsToShow = _logic.GetCarByBudget(maxPrice.Value);
            }
            else
            {
                carsToShow = _logic.GetAll();
            }

            dgvCars.DataSource = null;
            dgvCars.Columns.Clear();

            dgvCars.DataSource = carsToShow;
        }



        /// <summary>
        /// Обрабатывает событие клика по кнопке "Создать".
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {
            AddBrandFormView addBrandFormView = new AddBrandFormView(_logic);

            if (addBrandFormView.ShowDialog() == DialogResult.OK)
            {
                UpdateTable();
            }
        }

        /// <summary>
        /// Обрабатывает событие клика по кнопке "Обновить". 
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (dgvCars.SelectedRows.Count > 0)
            {
                int selectedId = Convert.ToInt32(dgvCars.SelectedRows[0].Cells[0].Value);
                UpdateBrandFormView updateBrandFormView = new UpdateBrandFormView(_logic, selectedId);

                if (updateBrandFormView.ShowDialog() == DialogResult.OK)
                {
                    UpdateTable();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выделите в таблице строку с автомобилем, который хотите обновить.",
                                "Выбор не сделан", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Обрабатывает событие клика по кнопке "Бюджет".
        /// </summary>
        private void BudgetButton_Click(object sender, EventArgs e)
        {
            BudgetFormView budgetFormView = new BudgetFormView();

            if (budgetFormView.ShowDialog() == DialogResult.OK)
            {
                decimal maxBudget = budgetFormView.EnteredBudget;
                UpdateTable(maxBudget);
            }
        }

        /// <summary>
        /// Обрабатывает событие клика по кнопке "Удалить".
        /// </summary>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dgvCars.SelectedRows.Count > 0)
            {
                int selectedId = Convert.ToInt32(dgvCars.SelectedRows[0].Cells[0].Value);

                if (_logic.Delete(selectedId))
                {
                    UpdateTable();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выделите строку для удаления.", "Выбор не сделан", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Обрабатывает событие клика по кнопке "Сортировать по бренду". 
        /// </summary>
        private void SortByBrandButton_Click(object sender, EventArgs e)
        {
            List<Car> allCars = _logic.GetAll();

            if (allCars.Count == 0)
            {
                MessageBox.Show("Список автомобилей пуст. Нечего сортировать.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var sortedCars = allCars.OrderBy(car => car.Brand).ToList();

            dgvCars.DataSource = null;
            dgvCars.DataSource = sortedCars;
        }

        /// <summary>
        /// Обрабатывает событие клика по кнопке "Группировать по бренду". 
        /// </summary>
        private void GroupByBrandButton_Click(object sender, EventArgs e)
        {
            Dictionary<Car.CarBrand, List<Car>> groupedData = _logic.GroupByBrand();

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

            foreach (KeyValuePair<Car.CarBrand, List<Car>> pair in groupedData)
            {
                Car.CarBrand brand = pair.Key;
                List<Car> carsInGroup = pair.Value;

                int headerIndex = dgvCars.Rows.Add();

                dgvCars.Rows[headerIndex].Cells[0].Value = $"*Группа: {brand} (Количество: {carsInGroup.Count})";

                dgvCars.Rows[headerIndex].DefaultCellStyle.Font = new Font(dgvCars.Font, FontStyle.Bold);
                dgvCars.Rows[headerIndex].DefaultCellStyle.BackColor = Color.LightGray;
                dgvCars.Rows[headerIndex].ReadOnly = true;

                foreach (Car car in carsInGroup)
                {
                    string indentedBrand = "    " + car.Brand.ToString();
                    dgvCars.Rows.Add(car.Id, indentedBrand, car.Price.ToString("C"));
                }
            }
        }



        /// <summary>
        /// Обрабатывает событие клика по кнопке "Вернуть в исходное состояние". 
        /// </summary>
        private void ResetFilterButton_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }

        /// <summary>
        /// Обрабатывает событие загрузки главной формы. 
        /// </summary>
        private void MainFormView_Load(object sender, EventArgs e)
        {
            InitTable();
            UpdateTable();
        }
    }
}
