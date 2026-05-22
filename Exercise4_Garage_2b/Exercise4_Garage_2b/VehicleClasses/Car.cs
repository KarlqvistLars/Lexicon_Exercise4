using Exercise4_Garage_2b.MenuClasses;
using static Exercise4_Garage_2b.Utilities;
namespace Exercise4_Garage_2b {
    internal class Car : Vehicle {
        private int _numberOfDoors;
        private int _wheels;
        public Car() {

        }
        public Car(
            string uuid,
            string color,
            int weight,
            decimal length,
            int numberOfDoors,
            int wheels)
            : base(uuid, color, weight, length, VType.Car) {
            _numberOfDoors = numberOfDoors;
            _wheels = wheels;
        }
        public string Uuid { get => this.Uuid; }
        public string Color { get => this.Color; set => ((IVehicle)this).Color = value; }
        public int Weight { get => this.Weight; set => ((IVehicle)this).Weight = value; }
        public decimal Length { get => this.Length; set => ((IVehicle)this).Length = value; }
        //public new string Type => VType.Car.ToString();
        public int NumberOfDoors {
            get => _numberOfDoors;
            set => _numberOfDoors = value;
        }
        public int Wheels {
            get => _wheels;
            set => _wheels = value;
        }
        public string? ToString2() {
            return $"{Tab}{Cap(Text.Bil) + Text.medRegistrering}: {Uuid}\n" +
                        $"{Tab}{Cap(Text.Color)}: {Color}, {Cap(Text.Vikt)}: {Weight}, {Cap(Text.Length)}: {Length}\n" +
                        $"{Tab}{Cap(Text.NumDoors)}: {NumberOfDoors}, {Cap(Text.Wheel)}: {Wheels}";
        }
        internal static string[] InData() {
            string[] data = new string[4];
            Console.Write($"{Tab}{Cap(Text.NumDoors)}: ");
            data[0] = Utilities.InputInteger(Console.ReadLine() ?? string.Empty);
            Console.Write($"{Tab}{Cap(Text.Wheel)}: ");
            data[1] = Utilities.InputInteger(Console.ReadLine() ?? string.Empty);
            return data;
        }
        public string ToStringTypeSpec() {
            return $"[Wheels:{Wheels};NumberOfDoors:{NumberOfDoors}]";
        }
    }
}
