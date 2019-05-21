namespace КП
{
    public interface ISqlData
    {
        string Name { get; set; }
        string Color { get; set; }
        decimal Price { get; set; }
        string Mark { get; set; }
        string Fuel { get; set; }
        int EnginePower { get; set; }
        int EngineVolume { get; set; }
        int TankVolume { get; set; }
        byte[] Image { get; set; }
    }
}
