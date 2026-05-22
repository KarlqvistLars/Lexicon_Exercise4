using Exercise4_Garage_2b.MenuClasses;
using static Exercise4_Garage_2b.Utilities;
namespace Exercise4_Garage_2b.VehicleClasses {
    internal class Boat : Vehicle {
        decimal maxWaterDepth;
        decimal maxSpeed;
        decimal deplacement;

        public Boat(string uuid, string color, int weight, decimal length, decimal maxWaterDepth, decimal maxSpeed, decimal deplacement)
            : base(uuid, color, weight, length, VType.Boat) {
            this.maxWaterDepth = maxWaterDepth;
            this.maxSpeed = maxSpeed;
            this.deplacement = deplacement;
        }
        public new string Uuid { get => this.Uuid; }
        public new string Color { get => this.Color; set => ((IVehicle)this).Color = value; }
        public new int Weight { get => this.Weight; set => ((IVehicle)this).Weight = value; }
        public new decimal Length { get => this.Length; set => ((IVehicle)this).Length = value; }
        public new string Type => VType.Boat.ToString();
        public decimal MaxWaterDepth {
            get => maxWaterDepth;
            set => maxWaterDepth = value;
        }
        public decimal MaxSpeed {
            get => maxSpeed;
            set => maxSpeed = value;
        }
        public decimal Deplacement {
            get => deplacement;
            set => deplacement = value;
        }
        public string? ToString2() {
            return $"{Tab}{Cap(Text.Boat)}{Text.medRegistrering}: {Uuid}\n" +
                        $"{Tab}{Cap(Text.Color)}: {Color}, {Cap(Text.Vikt)}: {Weight}, {Cap(Text.Length)}: {Length}\n" +
                        $"{Tab}{Cap(Text.MaxWaterDepth)}: {MaxWaterDepth}, {Cap(Text.MaxSpeed)}: {MaxSpeed}, {Cap(Text.Deplacement)}: {Deplacement}";
        }
        internal static string[] InData() {
            string[] data = new string[4];
            Console.Write($"{Tab}{Cap(Text.MaxWaterDepth)}: ");
            data[0] = InputDecimal(Console.ReadLine() ?? string.Empty);
            Console.Write($"{Tab}{Cap(Text.MaxSpeed)}: ");
            data[1] = InputDecimal(Console.ReadLine() ?? string.Empty);
            Console.Write($"{Tab}{Cap(Text.Deplacement)}: ");
            data[2] = InputDecimal(Console.ReadLine() ?? string.Empty);
            return data;
        }
        public string ToStringTypeSpec() {
            return $"[MaxWaterDepth:{MaxWaterDepth};MaxSpeed:{MaxSpeed};Deplacement:{Deplacement}]";
        }
    }
}
