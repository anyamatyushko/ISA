using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ISA.WinFormsView
{
    public partial class BudgetFormView : Form
    {
        public decimal EnteredBudget { get; private set; }

        public BudgetFormView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обрабатывает событие загрузки формы бюджета.
        /// </summary>
        private void BudgetFormView_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Обрабатывает событие клика по кнопке "Сохранить".
        /// </summary>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox1.Text, out decimal budget))
            {
                if (budget < 0)
                {
                    MessageBox.Show("Бюджет не может быть отрицательным!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                EnteredBudget = budget;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректное числовое значение бюджета.", "Неверный формат", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

