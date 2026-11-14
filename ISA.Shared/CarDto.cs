namespace ISA.Shared
{
    public class CarDto
    {
        public int Id { get; set; }
        public CarBrandDto Brand { get; set; }
        public decimal Price { get; set; }
    }

    public enum CarBrandDto
    {
        BMW,
        Mercedes,
        Volvo,
        Audi,
        Volkswagen
    }

}
