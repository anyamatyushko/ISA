using System;
using System.Windows.Forms;
using ISA.Shared;
using static ISA.Shared.CarDto;

namespace ISA.WinFormsView
{
    public partial class UpdateBrandFormView : Form
    {
        private readonly CarBrandDto _currentBrand;

        public CarBrandDto SelectedBrand { get; private set; }
        public decimal EnteredPrice { get; private set; }

        // Принимаем текущий бренд машины из MainFormView (на случай, если юзер нажмет "Далее")
        public UpdateBrandFormView(CarBrandDto currentBrand, decimal currentPrice)
        {
            InitializeComponent();
            _currentBrand = currentBrand;
        }

        private void OpenUpdatePriceForm(CarBrandDto newBrand)
        {
            UpdatePriceFormView updatePriceForm = new UpdatePriceFormView();

            if (updatePriceForm.ShowDialog() == DialogResult.OK)
            {
                SelectedBrand = newBrand;
                EnteredPrice = updatePriceForm.EnteredPrice;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void UpdateBMWButton_Click(object sender, EventArgs e) => OpenUpdatePriceForm(CarBrandDto.BMW);
        private void UpdateMersedesButton_Click(object sender, EventArgs e) => OpenUpdatePriceForm(CarBrandDto.Mercedes);
        private void UpdateVolvoButton_Click(object sender, EventArgs e) => OpenUpdatePriceForm(CarBrandDto.Volvo);
        private void UpdateAudiButton_Click(object sender, EventArgs e) => OpenUpdatePriceForm(CarBrandDto.Audi);
        private void UpdateVolkswagenButton_Click(object sender, EventArgs e) => OpenUpdatePriceForm(CarBrandDto.Volkswagen);

        /// <summary>
        /// Обрабатывает событие клика по кнопке "Далее" (оставляет бренд без изменений). 
        /// </summary>
        private void NextButton_Click(object sender, EventArgs e)
        {
            OpenUpdatePriceForm(_currentBrand);
        }
    }
}
