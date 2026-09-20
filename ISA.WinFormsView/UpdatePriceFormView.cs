using System;
using System.Windows.Forms;
using ISA.Model;

namespace ISA.WinFormsView
{
    public partial class UpdatePriceFormView : Form
    {
        private Logic _logic;
        private int _carId;
        private Car.CarBrand _newBrand;
        public UpdatePriceFormView(Logic logic, int carId, Car.CarBrand newBrand)
        {
            InitializeComponent();
            _logic = logic;
            _carId = carId;
            _newBrand = newBrand;
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
                    MessageBox.Show("Цена не может быть отрицательной!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool isUpdated = _logic.UpdateCar(_carId, _newBrand, enteredPrice);

                if (isUpdated)
                {
 
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не удалось обновить данные автомобиля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректное числовое значение цены.", "Неверный формат", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
