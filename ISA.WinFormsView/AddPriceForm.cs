using System;
using System.Windows.Forms;

namespace ISA.WinFormsView
{
    public partial class AddPriceFormView : Form
    {
        public decimal EnteredPrice { get; private set; }

        public AddPriceFormView()
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
                    MessageBox.Show("Неправильный ввод цены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                EnteredPrice = enteredPrice;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильный ввод цены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click_1(object sender, EventArgs e) { }
    }
}
