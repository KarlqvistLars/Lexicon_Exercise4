using Exercise4_Garage_2.Interfaces;

namespace Exercise4_Garage_2
{
    public class Vehicle : IVehicle
    {
        readonly string tab = new string(' ', 3);
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
        public string Tab { get => tab; }
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
        public static string Cap(string text)
        {
            return string.IsNullOrEmpty(text)
                ? text
                : char.ToUpper(text[0]) + text[1..];
        }
    }
}