using Exercise3.UtilitesClasses;

namespace Exercise3
{
    public class Motorcycle : Vehicle
    {
        private int _cubicInch;
        private int _wheels = 2;
        public Motorcycle(string uuid, string color, int weight, int length, int cubicInch, int wheels)
            : base(uuid, color, weight, length, "Motorcycle")
        {
            this._cubicInch = cubicInch;
            this._wheels = wheels;
        }
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

        public override string ToString()
        {
            return $"{Utilities.vTab}Motorcykel nr: {Uuid}\n{Utilities.vTab}Färg: {Color}\n{Utilities.vTab}Vikt: {Weight} Kg\n{Utilities.vTab}Längd: {Length} m\n{Utilities.vTab}Kubik: {CubicInch} cc\n";
        }
        string thisType = "Motorcykel";
        public override string ToString2()
        {
            return $"{Utilities.vTab}\u001b[4m{thisType} nr: {Uuid}\u001b[0m\n{Utilities.vTab}Färg: {Color}, Vikt: {Weight} Kg, Längd: {Length} m\n{Utilities.vTab}\u001b[4mSpecifikt för {thisType}:\u001b[0m\n{Utilities.vTab}Kubik: {CubicInch} cc";
        }
        public string ToStringTypeSpec()
        {
            return $"[Wheels:{Wheels};CubicInch:{CubicInch}]";
        }
    }
}