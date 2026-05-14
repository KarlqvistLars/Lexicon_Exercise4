namespace Exercise4_Garage_2.Interfaces
{
    public interface IVehicle
    {
        string? Uuid { get; }
        string Color { get; set; }
        int Weight { get; set; }
        int Length { get; set; }
        string Type { get; }
    }
}
