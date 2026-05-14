namespace Exercise4_Garage_2.Interfaces
{
    public class Vehicle : IVehicle
    {
        private string? _uuid;
        private string? _color;
        private int _weight;
        private int _length;
        private string? _type;
        public Vehicle()
        {
            _color = string.Empty;
            _type = string.Empty;
        }
        internal Vehicle(string uuid, string color, int weight, int length, string type = "")
        {
            this._uuid = uuid;
            this._color = color;
            this._weight = weight;
            this._length = length;
            this._type = type;
        }
        internal string? Uuid
        {
            get => _uuid;
            set => _uuid = value;
        }
        internal string Color
        {
            get => _color ?? string.Empty;
            set => _color = value;
        }
        internal int Weight
        {
            get => _weight;
            set => _weight = value;
        }
        internal int Length
        {
            get => _length;
            set => _length = value;
        }
        internal string Type
        {
            get => _type ?? string.Empty;
        }
        string? IVehicle.Uuid => Uuid;
        string IVehicle.Color { get => Color; set => Color = value; }
        int IVehicle.Weight { get => Weight; set => Weight = value; }
        int IVehicle.Length { get => Length; set => Length = value; }
        string IVehicle.Type => Type;
        public override string ToString()
        {
            return $"{Type} nr: {Uuid}\n  Färg: {Color}\n  Vikt: {Weight} Kg\n  Längd: {Length} m\n";
        }
    }
}