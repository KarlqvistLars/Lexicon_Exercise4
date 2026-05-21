using Exercise4_Garage_2b.MenuClasses;
using static Exercise4_Garage_2b.Utilities;
namespace Exercise4_Garage_2b.VehicleClasses {
    internal class Airplane : Vehicle {
        int liftCapacity;
        decimal wingSpan;
        private int passengers;
        public Airplane(string uuid, string color, int weight, decimal length, int liftCapacity, decimal wingSpan, int passengers)
            : base(uuid, color, weight, length, VType.Airplane) {
            this.liftCapacity = liftCapacity;
            this.wingSpan = wingSpan;
            this.passengers = passengers;
        }
        public new string Uuid { get => this.Uuid; }
        public new string Color { get => this.Color; set => ((IVehicle)this).Color = value; }
        public new int Weight { get => this.Weight; set => ((IVehicle)this).Weight = value; }
        public new decimal Length { get => this.Length; set => ((IVehicle)this).Length = value; }
        public new string Type => VType.Airplane.ToString();
        public int LiftCapacity {
            get => liftCapacity;
            set => liftCapacity = value;
        }
        public decimal WingSpan {
            get => wingSpan;
            set => wingSpan = value;
        }
        public int Passengers {
            get => passengers;
            set => passengers = value;
        }

        public string? ToString2() {
            return $"{Tab}{Cap(Text.Flygplan)}{Text.medRegistrering}: {Uuid}\n" +
                        $"{Tab}{Cap(Text.Color)}: {Color}, {Cap(Text.Vikt)}: {Weight}, {Cap(Text.Length)}: {Length}\n" +
                        $"{Tab}{Cap(Text.Lyftkapacitet)}: {LiftCapacity}, {Cap(Text.Vingbredd)}: {WingSpan}, {Cap(Text.Pax)}: {Passengers}";
        }
        internal static string[] InData() {
            string[] data = new string[4];
            Console.Write($"{Tab}{Cap(Text.Lyftkapacitet)}: ");
            data[0] = Console.ReadLine() ?? string.Empty;
            Console.Write($"{Tab}{Cap(Text.Vingbredd)}: ");
            data[1] = Console.ReadLine() ?? string.Empty;
            Console.Write($"{Tab}{Cap(Text.Pax)}: ");
            data[2] = Console.ReadLine() ?? string.Empty;
            return data;
        }
        public string ToStringTypeSpec() {
            return $"[LiftCapacity:{LiftCapacity};WingSpan:{WingSpan};Passengers:{Passengers}]";
        }
    }
}

