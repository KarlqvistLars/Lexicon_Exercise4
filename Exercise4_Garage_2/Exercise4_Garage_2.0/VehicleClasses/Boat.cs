using Exercise3.UtilitesClasses;

namespace Exercise3
{
    public class Boat : Vehicle
    {
        decimal maxWaterDepth;
        decimal maxSpeed;
        decimal deplacement;

        public Boat(string uuid, string color, int weight, int length, decimal maxWaterDepth, decimal maxSpeed, decimal deplacement)
            : base(uuid, color, weight, length, "Boat")
        {
            this.maxWaterDepth = maxWaterDepth;
            this.maxSpeed = maxSpeed;
            this.deplacement = deplacement;
        }

        public decimal MaxWaterDepth
        {
            get => maxWaterDepth;
            set => maxWaterDepth = value;
        }

        public decimal MaxSpeed
        {
            get => maxSpeed;
            set => maxSpeed = value;
        }

        public decimal Deplacement
        {
            get => deplacement;
            set => deplacement = value;
        }

        public override string ToString()
        {
            return $"{Utilities.vTab}Båt nr: {Uuid}\n{Utilities.vTab}Färg: {Color}\n{Utilities.vTab}Vikt: {Weight} Kg\n{Utilities.vTab}Längd: {Length} m\n{Utilities.vTab}Maxdjup: {MaxWaterDepth} m\n{Utilities.vTab}Maxhastighet: {MaxSpeed} kn\n{Utilities.vTab}Deplacement: {Deplacement} kg\n";
        }

        string thisType = "Båt";
        public override string ToString2()
        {
            return $"{Utilities.vTab}\u001b[4m{thisType} nr: {Uuid}\u001b[0m\n{Utilities.vTab}Färg: {Color}, Vikt: {Weight} Kg, Längd: {Length} m\n{Utilities.vTab}\u001b[4mSpecifikt för {thisType}:\u001b[0m\n{Utilities.vTab}Maxdjup: {MaxWaterDepth} m, Maxhastighet: {MaxSpeed} kn, Deplacement: {Deplacement} kg";
        }
        public string ToStringTypeSpec()
        {
            return $"[MaxWaterDepth:{MaxWaterDepth};MaxSpeed:{MaxSpeed};Deplacement:{Deplacement}]";
        }
    }
}