using System;
using System.Windows.Forms;
using ISA.Model;

namespace ISA.WinFormsView
{
    public partial class UpdateBrandFormView : Form
    {
        private Logic _logic;
        private int _carId;
        public UpdateBrandFormView(Logic logic, int carId)
        {
            InitializeComponent();
            _logic = logic;
            _carId = carId;
        }

        /// <summary>
        /// Вспомогательный метод, который открывает окно изменения цены для указанного бренда.
        /// Если обновление прошло успешно, закрывает текущую форму.
        /// </summary>
        /// <param name="newBrand">Новый выбранный бренд автомобиля.</param>
        private void OpenUpdatePriceForm(Car.CarBrand newBrand)
        {
            UpdatePriceFormView updatePriceForm = new UpdatePriceFormView(_logic, _carId, newBrand);

            if (updatePriceForm.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// Обрабатывает событие клика по кнопке обновления бренда на BMW.
        /// </summary>
        private void UpdateBMWButton_Click(object sender, EventArgs e)
        {
            OpenUpdatePriceForm(Car.CarBrand.BMW);
        }

        /// <summary>
        /// Обрабатывает событие клика по кнопке обновления бренда на Mercedes.
        /// </summary>
        private void UpdateMersedesButton_Click(object sender, EventArgs e)
        {
            OpenUpdatePriceForm(Car.CarBrand.Mercedes);
        }

        /// <summary>
        /// Обрабатывает событие клика по кнопке обновления бренда на Volvo.
        /// </summary>
        private void UpdateVolvoButton_Click(object sender, EventArgs e)
        {
            OpenUpdatePriceForm(Car.CarBrand.Volvo);
        }

        /// <summary>
        /// Обрабатывает событие клика по кнопке обновления бренда на Audi.
        /// </summary>
        private void UpdateAudiButton_Click(object sender, EventArgs e)
        {
            OpenUpdatePriceForm(Car.CarBrand.Audi);
        }

        /// <summary>
        /// Обрабатывает событие клика по кнопке обновления бренда на Volkswagen.
        /// </summary>
        private void UpdateVolkswagenButton_Click(object sender, EventArgs e)
        {
            OpenUpdatePriceForm(Car.CarBrand.Volkswagen);
        }

        /// <summary>
        /// Обрабатывает событие клика по кнопке "Далее". 
        /// </summary>
        private void NextButton_Click(object sender, EventArgs e)
        {
            Car currentCar = _logic.GetCarById(_carId);
            if (currentCar != null)
            {
                OpenUpdatePriceForm(currentCar.Brand);
            }
        }
    }
}
