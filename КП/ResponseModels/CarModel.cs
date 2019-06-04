namespace КП
{
    public class CarModel : ISqlDataCars
    {
        public string Name { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }

        public string Mark { get; set; }

        public string Fuel { get; set; }

        public int EnginePower { get; set; }

        public int EngineVolume { get; set; }

        public int TankVolume { get; set; }

        public decimal Discount { get; set; }
    }
}
