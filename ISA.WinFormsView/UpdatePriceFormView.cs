using System;
using System.Windows.Forms;

namespace ISA.WinFormsView
{
    public partial class UpdatePriceFormView : Form
    {
        public decimal EnteredPrice { get; private set; }

        public UpdatePriceFormView()
        {
            InitializeComponent();
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

                EnteredPrice = enteredPrice;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректное числовое значение цены.", "Неверный формат", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
