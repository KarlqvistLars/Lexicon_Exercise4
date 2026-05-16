using Exercise4_Garage_2.MenuClasses;
using static Exercise4_Garage_2.Utilities;
namespace Exercise4_Garage_2
{
    internal class Car : Vehicle
    {
        int numberOfDoors;
        int wheels;
        public Car(string uuid, string color, int weight, decimal length, int numberOfDoors, int wheels)
        : base(uuid, color, weight, length, VType.Car)
        {
            this.numberOfDoors = numberOfDoors;
            this.wheels = wheels;
        }
        public new string Uuid { get => this.Uuid; }
        public new string Color { get => this.Color; set => ((IVehicle)this).Color = value; }
        public new int Weight { get => this.Weight; set => ((IVehicle)this).Weight = value; }
        public new decimal Length { get => this.Length; set => ((IVehicle)this).Length = value; }
        public new string Type => VType.Car.ToString();
        public int NumberOfDoors
        {
            get => numberOfDoors;
            set => numberOfDoors = value;
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
                        $"{Tab}{Cap(Text.NumDoors)}: {NumberOfDoors}, {Cap(Text.Wheel)}: {Wheels}";
        }

        internal static string[] InDataCar()
        {
            string[] data = new string[4];
            Console.WriteLine($"{Tab}{Text.RadAddVehicle}:");
            Console.Write($"{Tab}{Cap(Text.NumDoors)}: ");
            data[0] = Console.ReadLine() ?? string.Empty;
            Console.Write($"{Tab}{Cap(Text.Wheel)}: ");
            data[1] = Console.ReadLine() ?? string.Empty;
            return data;
        }
    }
}
