using Exercise3.UtilitesClasses;

namespace Exercise3
{
    public class Airplane : Vehicle
    {
        int liftCapacity;
        decimal wingSpan;
        private int passengers;
        public Airplane(string uuid, string color, int weight, int length, int liftCapacity, decimal wingSpan, int passengers)
            : base(uuid, color, weight, length, "Airplane")
        {
            this.liftCapacity = liftCapacity;
            this.wingSpan = wingSpan;
            this.passengers = passengers;
        }
        public int LiftCapacity
        {
            get => liftCapacity;
            set => liftCapacity = value;
        }
        public decimal WingSpan
        {
            get => wingSpan;
            set => wingSpan = value;
        }
        public int Passengers
        {
            get => passengers;
            set => passengers = value;
        }
        public override string ToString()
        {
            return $"{Utilities.vTab}Flygplan nr: {Uuid}\n{Utilities.vTab}Färg: {Color}\n{Utilities.vTab}Vikt: {Weight} Kg\n{Utilities.vTab}Längd: {Length} m\n{Utilities.vTab}Lyftkapacitet: {LiftCapacity} kg\n{Utilities.vTab}Vingspann: {WingSpan} m\n{Utilities.vTab}Passagerare: {Passengers} st\n";
        }
        string thisType = "Flygplan";
        public override string ToString2()
        {
            return $"{Utilities.vTab}\u001b[4m{thisType} nr: {Uuid}\u001b[0m\n{Utilities.vTab}Färg: {Color}, Vikt: {Weight} Kg, Längd: {Length} m\n{Utilities.vTab}\u001b[4mSpecifikt för {thisType}:\u001b[0m\n{Utilities.vTab}Lyftkapacitet: {LiftCapacity} kg, Vingspann: {WingSpan} m, Pax: {Passengers} st";
        }
        public string ToStringTypeSpec()
        {
            return $"[LiftCapacity:{LiftCapacity};WingSpan:{WingSpan};Passengers:{Passengers}]";
        }
    }
}