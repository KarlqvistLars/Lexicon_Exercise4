using Exercise3.UtilitesClasses;

namespace Exercise3
{
    public class Car : Vehicle
    {
        int numberOfDoors;
        int wheels;

        public Car(string uuid, string color, int weight, int length, int numberOfDoors, int wheels)
            : base(uuid, color, weight, length, "Car")
        {
            this.numberOfDoors = numberOfDoors;
            this.wheels = wheels;
        }

        public int NumberOfDoors
        {
            get => numberOfDoors;
            set => numberOfDoors = value;
        }

        public int Wheels
        {
            get => wheels;
            set => wheels = value;
        }

        public override string ToString()
        {
            return $"{Utilities.vTab}Bil nr: {Uuid}\n{Utilities.vTab}Färg: {Color}\n{Utilities.vTab}Vikt: {Weight} Kg\n{Utilities.vTab}Längd: {Length} m\n{Utilities.vTab}Hjul: {Wheels} st\n{Utilities.vTab}Dörrar: {NumberOfDoors} st";
        }

        string thisType = "Bil";
        public override string ToString2()
        {
            return $"{Utilities.vTab}\u001b[4m{thisType} nr: {Uuid}\u001b[0m\n{Utilities.vTab}Färg: {Color}\tVikt: {Weight} Kg\tLängd: {Length} m\n{Utilities.vTab}\u001b[4mSpecifikt för {thisType}:\u001b\n[0m{Utilities.vTab}Hjul: {Wheels} st, Dörrar: {NumberOfDoors} st";
        }
        public string ToStringTypeSpec()
        {
            return $"[Wheels:{Wheels};NumberOfDoors:{NumberOfDoors}]";
        }
    }
}