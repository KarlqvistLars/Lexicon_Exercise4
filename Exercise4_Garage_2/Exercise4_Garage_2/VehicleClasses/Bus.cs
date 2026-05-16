using Exercise4_Garage_2.MenuClasses;
using static Exercise4_Garage_2.Utilities;
namespace Exercise4_Garage_2
{
    internal class Bus : Vehicle
    {
        int numberOfSeats;
        int wheels;
        public Bus(string uuid, string color, int weight, decimal length, int numberOfSeats, int wheels)
        : base(uuid, color, weight, length, VType.Bus)
        {
            this.numberOfSeats = numberOfSeats;
            this.wheels = wheels;
        }
        public new string Uuid { get => this.Uuid; }
        public new string Color { get => this.Color; set => ((IVehicle)this).Color = value; }
        public new int Weight { get => this.Weight; set => ((IVehicle)this).Weight = value; }
        public new decimal Length { get => this.Length; set => ((IVehicle)this).Length = value; }
        public new string Type => VType.Bus.ToString();
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
        public string? ToString2()
        {
            return $"{Tab}{Cap(Text.Bil) + Text.medRegistrering}: {Uuid}\n" +
                        $"{Tab}{Cap(Text.Color)}: {Color}, {Cap(Text.Vikt)}: {Weight}, {Cap(Text.Length)}: {Length}\n" +
                        $"{Tab}{Cap(Text.NumSeats)}: {numberOfSeats}, {Cap(Text.Wheel)}: {Wheels}";
        }

        internal static string[] InData()
        {
            string[] data = new string[4];
            Console.Write($"{Tab}{Cap(Text.NumSeats)}: ");
            data[0] = InputInteger(Console.ReadLine() ?? string.Empty);
            Console.Write($"{Tab}{Cap(Text.Wheel)}: ");
            data[1] = InputInteger(Console.ReadLine() ?? string.Empty);
            return data;
        }
    }
}