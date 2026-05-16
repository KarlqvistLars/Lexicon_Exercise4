using Exercise4_Garage_2.Interfaces;
using Exercise4_Garage_2.MenuClasses;

namespace Exercise4_Garage_2
{
    public class Handler : IHandler
    {
        public Handler() { }
        Garage<IVehicle> garage = new Garage<IVehicle>(1);

        public bool StartGarage(int garageSize, bool populate = false)
        {
            if (populate == false)
            {
                garage = new Garage<IVehicle>(garageSize);
                UI.MenuMain(garage);
            }
            else
            {
                garage = new Garage<IVehicle>(20);
                //Handler.AddStartVehicles(15); // Lägg till 15 slumpmässiga fordon
                UI.MenuMain(garage);
            }
            return true;
        }


        public void AddCar(Garage<IVehicle> garage)
        {
            string[] v = new string[4];
            string[] c = new string[4];
            string Title = $"{Text.LaggTill} {Text.Bil}.";
            Utilities.ShowHeader(Title);
            v = Vehicle.InDataVehicle(garage, Utilities.VType.Car);
            c = Car.InDataCar();
            garage.Add(new Car(v[0], v[1], int.Parse(v[2]), decimal.Parse(v[3]), int.Parse(c[0]), int.Parse(c[1])));
            Console.WriteLine($"\n{Utilities.Tab}{Text.LagtsTillGaraget}\n{garage.Last().ToString2(Utilities.VType.Car)}");
            Console.WriteLine($"{Utilities.Tab}{Utilities.Cap(Text.AntalFordon)}: {garage.Count}{Text.Av}{garage.Capacity}{Text.platser}");
            Console.WriteLine($"{Utilities.Tab}{Text.TryckRetur}");
            Console.ReadLine();
        }
























        public void AddBus(Garage<IVehicle> garage)
        {
            string Title = "Lägg till Buss";
            //ShowHeader(Title);

        }
        public void AddMotorcycle(Garage<IVehicle> garage)
        {
            string Title = $" Lägg till MC";
            //ShowHeader(Title);

        }
        public void AddBoat(Garage<IVehicle> garage)
        {
            string Title = $"Lägg till Båt";
            //ShowHeader(Title);

            //Console.WriteLine($"{Utilities.Tab}Denna båt har lagts till i garaget.\n{Utilities.Tab}Tryck Retur för att fortsätta...");
            Console.ReadLine();
        }
        public void AddAirplane(Garage<IVehicle> garage)
        {
            string Title = $"Lägg till FLP";
            //ShowHeader(Title);

            Console.WriteLine($"{Utilities.Tab}Detta flygplan har lagts till i garaget.\n{Utilities.Tab}Tryck Retur för att fortsätta...");
            Console.ReadLine();
        }
        public void AddRandomVehicles(Garage<IVehicle> garage, int count = 0)
        {
            string Title = "Lägg till slumpade fordon";

            Console.WriteLine($"{Utilities.Tab}Tryck på valfri tangent för att återgå till huvudmenyn...");
            Console.ReadLine();
        }


        public void AddVehicle(Garage<IVehicle> garage)
        {
            string Title = "Lägg till fordon";
            //ShowHeader(Title);
            Console.WriteLine($"{Utilities.Tab}Tryck på valfri tangent för att återgå till huvudmenyn...");
            Console.ReadLine();
        }

        public void RemoveVehicle(Garage<IVehicle> garage)
        {
            string Title = "Ta bort fordon";
            //ShowHeader(Title);
            Console.WriteLine($"{Utilities.Tab}Tryck på valfri tangent för att återgå till huvudmenyn...");
            Console.ReadLine();

        }
    }
}
