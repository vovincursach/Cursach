namespace КП
{
    public interface ISqlDataCars
    {
        string Name { get; set; }
        string Color { get; set; }
        decimal Price { get; set; }
        string Mark { get; set; }
        string Fuel { get; set; }
        int EnginePower { get; set; }
        int EngineVolume { get; set; }
        int TankVolume { get; set; }
        decimal Discount { get; set; }
    }
}
