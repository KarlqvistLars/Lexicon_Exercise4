using static Exercise4_Garage_2b.Utilities;

namespace Exercise4_Garage_2b {
    public interface IVehicle {
        string Uuid { get; set; }
        string Color { get; set; }
        int Weight { get; set; }
        decimal Length { get; set; }
        VType Type { get; }
        public string[] InDataVehicle(Garage<IVehicle> garage, VType vehicleType);
        public string? ToString2(VType vehicleType = VType.None);
    }
}
