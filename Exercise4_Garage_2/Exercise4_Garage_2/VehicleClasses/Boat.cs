using Exercise4_Garage_2.MenuClasses;
using static Exercise4_Garage_2.IVehicle;
namespace Exercise4_Garage_2.VehicleClasses
{
    internal class Boat : Vehicle
    {
        decimal maxWaterDepth;
        decimal maxSpeed;
        decimal deplacement;

        public Boat(string uuid, string color, int weight, int length, decimal maxWaterDepth, decimal maxSpeed, decimal deplacement)
            : base(uuid, color, weight, length, VehicleType.Boat)
        {
            this.maxWaterDepth = maxWaterDepth;
            this.maxSpeed = maxSpeed;
            this.deplacement = deplacement;
        }
        public new string Uuid { get => this.Uuid; }
        public new string Color { get => this.Color; set => ((IVehicle)this).Color = value; }
        public new int Weight { get => this.Weight; set => ((IVehicle)this).Weight = value; }
        public new int Length { get => this.Length; set => ((IVehicle)this).Length = value; }
        public new string Type => VehicleType.Boat.ToString();
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
        public string? ToString(int variant = 0)
        {
            switch (variant)
            {
                case 1:
                    return $"{Tab}{Cap(Text.Bil) + Text.medRegistrering}: {Uuid}\n" +
                        $"{Tab}{Cap(Text.Color)}: {Color}, {Cap(Text.Vikt)}: {Weight}, {Cap(Text.Length)}: {Length}\n";
                case 2:
                    return $"{Tab}{Cap(Text.MaxWaterDepth)}: {MaxWaterDepth}, {Cap(Text.MaxSpeed)}: {MaxSpeed}, {Cap(Text.Deplacement)}: {Deplacement}";
                default:
                    return $"Typ av utskrift ej definierad";
            }
        }
    }
}
