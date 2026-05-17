using Exercise4_Garage_2.MenuClasses;
using static Exercise4_Garage_2.Utilities;
namespace Exercise4_Garage_2.VehicleClasses
{
    internal class Motorcycle : Vehicle
    {
        private int _cubicInch;
        private int _wheels = 2;
        public Motorcycle(string uuid, string color, int weight, decimal length, int cubicInch, int wheels)
            : base(uuid, color, weight, length, VType.Motorcycle)
        {
            this._cubicInch = cubicInch;
            this._wheels = wheels;
        }
        public new string Uuid { get => this.Uuid; }
        public new string Color { get => this.Color; set => ((IVehicle)this).Color = value; }
        public new int Weight { get => this.Weight; set => ((IVehicle)this).Weight = value; }
        public new decimal Length { get => this.Length; set => ((IVehicle)this).Length = value; }
        public new string Type => VType.Motorcycle.ToString();
        public int CubicInch
        {
            get => _cubicInch;
            set => _cubicInch = value;
        }
        public int Wheels
        {
            get => _wheels;
            set => _wheels = value;
        }
        public string? ToString2()
        {
            return $"{Tab}{Cap(Text.Bil) + Text.medRegistrering}: {Uuid}\n" +
                        $"{Tab}{Cap(Text.Color)}: {Color}, {Cap(Text.Vikt)}: {Weight}, {Cap(Text.Length)}: {Length}\n" +
                        $"{Tab}{Cap(Text.CubicInch)}: {CubicInch}, {Cap(Text.Wheel)}: {Wheels}";
        }
        internal static string[] InData()
        {
            string[] data = new string[4];
            Console.Write($"{Tab}{Cap(Text.CubicInch)}: ");
            data[0] = InputInteger(Console.ReadLine() ?? string.Empty);
            Console.Write($"{Tab}{Cap(Text.Wheel)}: ");
            data[1] = InputInteger(Console.ReadLine() ?? string.Empty);
            return data;
        }
    }
}
