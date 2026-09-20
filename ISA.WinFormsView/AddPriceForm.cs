using ISA.Model;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ISA.WinFormsView
{
    public partial class AddPriceFormView : Form
    {
        private Logic _logic;
        private Car.CarBrand _selectedBrand;

        public AddPriceFormView(Logic logic, Car.CarBrand brand)
        {
            InitializeComponent();
            _logic = logic;
            _selectedBrand = brand;
        }

        /// <summary>
        /// Обрабатывает событие клика по кнопке "Сохранить". 
        /// </summary>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox1.Text, out decimal enteredPrice))
            {
                if (enteredPrice < 0)
                {
                    MessageBox.Show("Неправильный ввод цены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _logic.AddCar(_selectedBrand, enteredPrice);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильный ввод цены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обрабатывает событие клика по текстовой метке label1.
        /// </summary>
        private void label1_Click_1(object sender, EventArgs e)
        {
        }
    }
}

