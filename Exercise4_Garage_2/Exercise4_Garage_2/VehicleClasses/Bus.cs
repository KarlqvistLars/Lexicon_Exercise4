using Exercise4_Garage_2.Interfaces;

namespace Exercise4_Garage_2.VehicleClasses
{
    public class Bus : Vehicle
    {
        int numberOfSeats;
        int wheels;
        public Bus(string uuid, string color, int weight, int length, int numberOfSeats, int wheels)
        : base(uuid, color, weight, length, VehicleType.Bus)
        {
            this.numberOfSeats = numberOfSeats;
            this.wheels = wheels;
        }
        public new string Uuid { get => this.Uuid; }
        public new string Color { get => this.Color; set => ((IVehicle)this).Color = value; }
        public new int Weight { get => this.Weight; set => ((IVehicle)this).Weight = value; }
        public new int Length { get => this.Length; set => ((IVehicle)this).Length = value; }
        public new string Type => VehicleType.Bus.ToString();
        public int NumberOfSeats
        {
            get => numberOfSeats;
            set => numberOfSeats = value;
        }
        public int Wheels
        {
            get => wheels;
            set => wheels = value;
        }
    }
}