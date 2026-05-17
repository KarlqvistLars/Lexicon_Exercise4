using Exercise4_Garage_2.MenuClasses;
using Exercise4_Garage_2.VehicleClasses;
using System.Text;
using static Exercise4_Garage_2.Utilities;
namespace Exercise4_Garage_2
{
    public class Vehicle : IVehicle
    {
        private string? _uuid;
        private string? _color;
        private int _weight;
        private decimal _length;
        private VType _type;
        public Vehicle()
        {
            _color = string.Empty;
            _type = VType.None;
        }
        public Vehicle(string uuid, string color, int weight, decimal length, VType type)
        {
            this._uuid = uuid;
            this._color = color;
            this._weight = weight;
            this._length = length;
            this._type = (VType)type;
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
        public decimal Length
        {
            get => _length;
            set => _length = value;
        }
        public VType Type
        {
            get => _type;
        }
        string[] IVehicle.InDataVehicle(Garage<IVehicle> garage, VType vType)
        {
            return InDataVehicle(garage, vType);
        }
        internal static string[] InDataVehicle(Garage<IVehicle> garage, VType vType, bool searchFlag = false)
        {
            string[] data = new string[4];
            if (searchFlag)
            {
                data[0] = string.Empty;
            }
            else
            {
                Console.WriteLine($"{Tab}{Cap(Text.RadAddVehicle)}: ");
                Console.Write($"{Tab}{Cap(Text.RegNum)}: ");
                data[0] = ReadInput(garage, 0, vType, searchFlag);
            }
            Console.Write($"{Tab}{Cap(Text.Color)} {Text.ColorChoise}: ");
            data[1] = ReadInput(garage, 1, vType, searchFlag);
            Console.Write($"{Tab}{Cap(Text.Vikt)}: ");
            data[2] = ReadInput(garage, 2, vType, searchFlag);
            Console.Write($"{Tab}{Cap(Text.Length)}: ");
            data[3] = ReadInput(garage, 3, vType, searchFlag);
            return data;
        }
        public static string Cap(string text)
        {
            return string.IsNullOrEmpty(text)
                ? text
                : char.ToUpper(text[0]) + text[1..];
        }
        public string? ToString3(VType valueType = VType.None)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Tab}{valueType.ToString()} {Text.medRegistrering}: {Uuid}");
            sb.AppendLine($"{Tab}{Cap(Text.Color)}: {Color}, {Cap(Text.Vikt)}: {Weight}, {Cap(Text.Length)}: {Length}");
            if (valueType != VType.None)
            {
                sb.Append(valueType switch
                {
                    VType.Car => $"{Tab}{Cap(Text.NumDoors)}: {((Car)this).NumberOfDoors}, {Cap(Text.Wheel)}: {((Car)this).Wheels}",
                    VType.Bus => $"{Tab}{Cap(Text.NumSeats)}: {((Bus)this).NumberOfSeats}, {Cap(Text.Wheel)}: {((Bus)this).Wheels}",
                    VType.Motorcycle => $"{Tab}{Cap(Text.Wheel)}: {((Motorcycle)this).Wheels}, {Cap(Text.CubicInch)}: {((Motorcycle)this).CubicInch}",
                    VType.Boat => $"{Tab}{Cap(Text.WaterDepth)}: {((Boat)this).MaxWaterDepth}, {Cap(Text.BoatSpeed)}: {((Boat)this).MaxSpeed}\n{Tab}{Cap(Text.Deplac)}: {((Boat)this).Deplacement}",
                    VType.Airplane => $"{Tab}{Cap(Text.Lyftkapacitet)}: {((Airplane)this).LiftCapacity}, {Cap(Text.Vingbredd)}: {((Airplane)this).WingSpan}, {Cap(Text.Pax)}: {((Airplane)this).Passengers}",
                    _ => $""
                });
            }
            else
            {
                return $"Typ av fordon ej definierad";
            }
            return sb.ToString();
        }

        public string? ToString2(VType valueType = VType.None)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Tab}{valueType.ToString()} {Text.medRegistrering}: {Uuid}");
            sb.AppendLine($"{Tab}{Cap(Text.Color)}: {Color}, {Cap(Text.Vikt)}: {Weight}, {Cap(Text.Length)}: {Length}");
            if (valueType != VType.None)
            {
                switch (valueType)
                {
                    case VType.Car:
                        sb.Append($"{Tab}{Cap(Text.NumDoors)}: {((Car)this).NumberOfDoors}, {Cap(Text.Wheel)}: {((Car)this).Wheels}");
                        break;
                    case VType.Bus:
                        sb.Append($"{Tab}{Cap(Text.NumSeats)}: {((Bus)this).NumberOfSeats}, {Cap(Text.Wheel)}: {((Bus)this).Wheels}");
                        break;
                    case VType.Motorcycle:
                        sb.Append($"{Tab}{Cap(Text.Wheel)}: {((Motorcycle)this).Wheels}, {Cap(Text.CubicInch)}: {((Motorcycle)this).CubicInch}");
                        break;
                    case VType.Boat:
                        sb.Append($"{Tab}{Cap(Text.WaterDepth)}: {((Boat)this).MaxWaterDepth}, {Cap(Text.BoatSpeed)}: {((Boat)this).MaxSpeed}\n{Tab}{Cap(Text.Deplac)}: {((Boat)this).Deplacement}");
                        break;
                    case VType.Airplane:
                        sb.Append($"{Tab}{Cap(Text.Lyftkapacitet)}: {((Airplane)this).LiftCapacity}, {Cap(Text.Vingbredd)}: {((Airplane)this).WingSpan}, {Cap(Text.Pax)}: {((Airplane)this).Passengers}");
                        break;
                    default:
                        return $"";
                }
            }
            else
            {
                return $"Typ av fordon ej definierad";
            }
            return sb.ToString();
        }

    }
}