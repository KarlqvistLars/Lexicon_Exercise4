using static Exercise4_Garage_2.Utilities;

namespace Exercise4_Garage_2
{
    public interface IVehicle
    {
        string Uuid { get; set; }
        string Color { get; set; }
        int Weight { get; set; }
        decimal Length { get; set; }
        string Type { get; }
        public string[] InDataVehicle(Garage<IVehicle> garage, VType vehicleType);
        public string? ToString2(VType vehicleType = VType.None);
    }
}
