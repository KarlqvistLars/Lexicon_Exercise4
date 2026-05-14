using Exercise4_Garage_2.MenuClasses;
using static Exercise4_Garage_2.IVehicle;
namespace Exercise4_Garage_2
{
    public class Vehicle : IVehicle
    {
        private string? _uuid;
        private string? _color;
        private int _weight;
        private int _length;
        private VehicleType _type;
        public Vehicle()
        {
            _color = string.Empty;
            _type = VehicleType.None;
        }
        public Vehicle(string uuid, string color, int weight, int length, ValueType type)
        {
            this._uuid = uuid;
            this._color = color;
            this._weight = weight;
            this._length = length;
            this._type = (VehicleType)type;
        }
        public static string Tab { get => new string(' ', 3); }
        public string? Uuid
        {
            get => _uuid;
            set => _uuid = value;
        }
        public string Color
        {
            get => _color ?? string.Empty;
            set => _color = value;
        }
        public int Weight
        {
            get => _weight;
            set => _weight = value;
        }
        public int Length
        {
            get => _length;
            set => _length = value;
        }
        public string Type
        {
            get => _type.ToString();
        }
        string[] IVehicle.InDataVehicle()
        {
            return InDataVehicle();
        }
        internal static string[] InDataVehicle()
        {
            string[] data = new string[4];
            Console.WriteLine($"{Tab}{Text.RadAddVehicle}:");
            Console.Write($"{Tab}{Cap(Text.RegNum)}: ");
            data[0] = Console.ReadLine() ?? string.Empty;
            Console.Write($"{Tab}{Cap(Text.Color)}: ");
            data[1] = Console.ReadLine() ?? string.Empty;
            Console.Write($"{Tab}{Cap(Text.Vikt)}: ");
            data[2] = Console.ReadLine() ?? "0";
            Console.Write($"{Tab}{Cap(Text.Length)}: ");
            data[3] = Console.ReadLine() ?? "0";
            return data;
        }
        public static string Cap(string text)
        {
            return string.IsNullOrEmpty(text)
                ? text
                : char.ToUpper(text[0]) + text[1..];
        }
    }
}