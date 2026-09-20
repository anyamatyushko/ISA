using System;
using System.Windows.Forms;
using ISA.Model;

namespace ISA.WinFormsView
{
    public partial class AddBrandFormView : Form
    {
        private Logic _logic;
        public AddBrandFormView(Logic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        /// <summary>
        /// Вспомогательный метод, который открывает окно ввода цены для выбранного бренда.
        /// Если цена сохранена успешно, закрывает текущую форму выбора бренда.
        /// </summary>
        /// <param name="brand">Выбранный бренд автомобиля.</param>
        private void OpenPriceForm(Car.CarBrand brand)
        {
            AddPriceFormView addPriceForm = new AddPriceFormView(_logic, brand);
            if (addPriceForm.ShowDialog() == DialogResult.OK)
            {

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// Обрабатывает событие клика по кнопке-логотипу бренда BMW.
        /// </summary>
        private void BMWButton_Click(object sender, EventArgs e)
        {
            OpenPriceForm(Car.CarBrand.BMW);
        }

        /// <summary>
        /// Обрабатывает событие клика по кнопке-логотипу бренда Mercedes.
        /// </summary>
        private void MersedesButton_Click(object sender, EventArgs e)
        {
            OpenPriceForm(Car.CarBrand.Mercedes);
        }

        /// <summary>
        /// Обрабатывает событие клика по кнопке-логотипу бренда Volvo.
        /// </summary>
        private void VolvoButton_Click(object sender, EventArgs e)
        {
            OpenPriceForm(Car.CarBrand.Volvo);
        }

        /// <summary>
        /// Обрабатывает событие клика по кнопке-логотипу бренда Audi.
        /// </summary>
        private void AudiButton_Click(object sender, EventArgs e)
        {
            OpenPriceForm(Car.CarBrand.Audi);
        }

        /// <summary>
        /// Обрабатывает событие клика по кнопке-логотипу бренда Volkswagen.
        /// </summary>
        private void VolkswagenButton_Click(object sender, EventArgs e)
        {
            OpenPriceForm(Car.CarBrand.Volkswagen);
        }
    }
}
