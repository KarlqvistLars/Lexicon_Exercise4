namespace Exercise4_Garage_2
{
    public interface IVehicle
    {
        string Uuid { get; set; }
        string Color { get; set; }
        int Weight { get; set; }
        int Length { get; set; }
        string Type { get; }
        enum VehicleType
        {
            None,
            Car,
            Bus,
            Boat,
            Truck,
            Motorcycle
        }
        public string[] InDataVehicle();
    }
}
