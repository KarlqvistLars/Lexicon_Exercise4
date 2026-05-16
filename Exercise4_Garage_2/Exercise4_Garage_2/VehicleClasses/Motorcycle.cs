using Exercise4_Garage_2.MenuClasses;
using static Exercise4_Garage_2.Utilities;
namespace Exercise4_Garage_2.VehicleClasses
{
    internal class Motorcycle : Vehicle
    {
        int numberOfSeats;
        int wheels;
        public Motorcycle(string uuid, string color, int weight, int length, int numberOfSeats, int wheels)
        : base(uuid, color, weight, length, VType.Motorcycle)
        {
            this.numberOfSeats = numberOfSeats;
            this.wheels = wheels;
        }
        public new string Uuid { get => this.Uuid; }
        public new string Color { get => this.Color; set => ((IVehicle)this).Color = value; }
        public new int Weight { get => this.Weight; set => ((IVehicle)this).Weight = value; }
        public new int Length { get => this.Length; set => ((IVehicle)this).Length = value; }
        public new string Type => VType.Motorcycle.ToString();
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
        public string? ToString(int variant = 0)
        {
            switch (variant)
            {
                case 1:
                    return $"{Tab}{Cap(Text.Bil) + Text.medRegistrering}: {Uuid}\n" +
                        $"{Tab}{Cap(Text.Color)}: {Color}, {Cap(Text.Vikt)}: {Weight}, {Cap(Text.Length)}: {Length}\n";
                case 2:
                    return $"{Tab}{Cap(Text.NumSeats)}: {numberOfSeats}, {Cap(Text.Wheel)}: {Wheels}";
                default:
                    return $"Typ av utskrift ej definierad";
            }
        }
    }
}
