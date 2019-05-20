namespace КП
{
    public class CarModel : ISqlData
    {
        public string Name { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }

        public string Mark { get; set; }

        public byte[] Image { get; set; }
    }
}
