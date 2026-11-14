using System;
using System.Windows.Forms;
using ISA.Shared;
using static ISA.Shared.CarDto;

namespace ISA.WinFormsView
{
    public partial class AddBrandFormView : Form
    {
        public CarBrandDto SelectedBrand { get; private set; }
        public decimal EnteredPrice { get; private set; }

        public AddBrandFormView()
        {
            InitializeComponent();
        }

        private void OpenPriceForm(CarBrandDto brand)
        {
            AddPriceFormView addPriceForm = new AddPriceFormView();
            if (addPriceForm.ShowDialog() == DialogResult.OK)
            {
                SelectedBrand = brand;
                EnteredPrice = addPriceForm.EnteredPrice;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BMWButton_Click(object sender, EventArgs e) => OpenPriceForm(CarBrandDto.BMW);
        private void MersedesButton_Click(object sender, EventArgs e) => OpenPriceForm(CarBrandDto.Mercedes);
        private void VolvoButton_Click(object sender, EventArgs e) => OpenPriceForm(CarBrandDto.Volvo);
        private void AudiButton_Click(object sender, EventArgs e) => OpenPriceForm(CarBrandDto.Audi);
        private void VolkswagenButton_Click(object sender, EventArgs e) => OpenPriceForm(CarBrandDto.Volkswagen);
    }
}
