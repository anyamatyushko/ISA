namespace ISA.Model
{
    public class Car
    {
        public enum CarBrand
        {
            BMW,
            Mercedes,
            Volvo,
            Audi,
            Volkswagen
        }
        public int Id { get; set; }
        public CarBrand Brand { get; set; }
        public decimal Price { get; set; }
    }
}