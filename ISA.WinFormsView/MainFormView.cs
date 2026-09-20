using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ISA.Model;

namespace ISA.WinFormsView
{
    public partial class MainFormView : Form
    {
     
        private Logic _logic = new Logic();
        public MainFormView()
        {
            InitializeComponent();
            InitTable();
        }

        /// <summary>
        /// Выполняет первичную настройку колонок и режима выделения таблицы.
        /// </summary>
        private void InitTable()
        {
            dgvCars.ColumnCount = 3;
            dgvCars.Columns[0].Name = "ID";
            dgvCars.Columns[1].Name = "Бренд";
            dgvCars.Columns[2].Name = "Цена";
            dgvCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// Обновляет строки таблицы на основе данных из бизнес-логики.
        /// </summary>
        /// <param name="maxPrice">Максимально допустимая цена автомобиля для фильтрации.</param>
        private void UpdateTable(decimal? maxPrice = null)
        {
            dgvCars.Rows.Clear();
            if (maxPrice.HasValue)
            {
                var filteredCars = _logic.GetCarByBudget(maxPrice.Value);
                foreach (var car in filteredCars)
                {
                    dgvCars.Rows.Add(car.Id, car.Brand.ToString(), car.Price.ToString("C"));
                }
            }
            else
            {
                int id = 1;
                int emptyCount = 0;
                while (true)
                {
                    var car = _logic.GetCarById(id);
                    if (car != null)
                    {
                        emptyCount = 0;
                        dgvCars.Rows.Add(car.Id, car.Brand.ToString(), car.Price.ToString("C"));
                    }
                    else
                    {
                        emptyCount++;
                    }

                    if (emptyCount > 20) break;
                    id++;
                }
            }
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

                if (_logic.DeleteCar(selectedId))
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
        /// Обрабатывает событие клика по кнопке "Сгруппировать по бренду". 
        /// </summary>
        private void GroupByBrandButton_Click(object sender, EventArgs e)
        {
            List<Car> allCars = _logic.GetCars();

            if (allCars.Count == 0)
            {
                MessageBox.Show("Список автомобилей пуст. Нечего группировать.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvCars.Rows.Clear();

            var sortedCars = allCars.OrderBy(car => car.Brand).ToList();

            foreach (Car car in sortedCars)
            {
                dgvCars.Rows.Add(car.Id, car.Brand.ToString(), car.Price.ToString("C"));
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
            UpdateTable();
        }
    }
}
