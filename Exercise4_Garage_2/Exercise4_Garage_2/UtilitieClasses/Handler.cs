using Exercise4_Garage_2.Interfaces;
using Exercise4_Garage_2.MenuClasses;
using Exercise4_Garage_2.VehicleClasses;

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
            c = Car.InData();
            garage.Add(new Car(v[0], v[1], int.Parse(v[2]), decimal.Parse(v[3]), int.Parse(c[0]), int.Parse(c[1])));
            Console.WriteLine($"\n{Utilities.Line30}{Utilities.Line30}");
            Console.WriteLine($"{Utilities.Tab}{Text.DennaBilen}{Text.LagtsTillGaraget}\n{garage.Last().ToString2(Utilities.VType.Car)}");
            Console.WriteLine($"{Utilities.Line30}{Utilities.Line30}");
            Console.WriteLine($"{Utilities.Tab}{Utilities.Cap(Text.AntalFordon)}{garage.Count}{Text.Av}{garage.Capacity}{Text.platser}");
            Console.WriteLine($"{Utilities.Tab}{Text.TryckRetur}");
            Console.ReadLine();
        }
        public void AddBus(Garage<IVehicle> garage)
        {
            string[] v = new string[4];
            string[] c = new string[4];
            string Title = $"{Text.LaggTill} {Text.Buss}.";
            Utilities.ShowHeader(Title);
            v = Vehicle.InDataVehicle(garage, Utilities.VType.Bus);
            c = Bus.InData();
            garage.Add(new Bus(v[0], v[1], int.Parse(v[2]), decimal.Parse(v[3]), int.Parse(c[0]), int.Parse(c[1])));
            Console.WriteLine($"\n{Utilities.Line30}{Utilities.Line30}");
            Console.WriteLine($"{Utilities.Tab}{Text.DennaBussen}{Text.LagtsTillGaraget}\n{garage.Last().ToString2(Utilities.VType.Bus)}");
            Console.WriteLine($"{Utilities.Line30}{Utilities.Line30}");
            Console.WriteLine($"{Utilities.Tab}{Utilities.Cap(Text.AntalFordon)}{garage.Count}{Text.Av}{garage.Capacity}{Text.platser}");
            Console.WriteLine($"{Utilities.Tab}{Text.TryckRetur}");
            Console.ReadLine();
        }
        public void AddMotorcycle(Garage<IVehicle> garage)
        {
            string[] v = new string[4];
            string[] c = new string[4];
            string Title = $"{Text.LaggTill} {Text.Motorcykel}.";
            Utilities.ShowHeader(Title);
            v = Vehicle.InDataVehicle(garage, Utilities.VType.Motorcycle);
            c = Motorcycle.InData();
            garage.Add(new Motorcycle(v[0], v[1], int.Parse(v[2]), decimal.Parse(v[3]), int.Parse(c[0]), int.Parse(c[1])));
            Console.WriteLine($"\n{Utilities.Line30}{Utilities.Line30}");
            Console.WriteLine($"{Utilities.Tab}{Text.DennaMotorcykeln}{Text.LagtsTillGaraget}\n{garage.Last().ToString2(Utilities.VType.Motorcycle)}");
            Console.WriteLine($"{Utilities.Line30}{Utilities.Line30}");
            Console.WriteLine($"{Utilities.Tab}{Utilities.Cap(Text.AntalFordon)}{garage.Count}{Text.Av}{garage.Capacity}{Text.platser}");
            Console.WriteLine($"{Utilities.Tab}{Text.TryckRetur}");
            Console.ReadLine();
        }
        public void AddBoat(Garage<IVehicle> garage)
        {
            string[] v = new string[4];
            string[] c = new string[4];
            string Title = $"{Text.LaggTill} {Text.Boat}.";
            Utilities.ShowHeader(Title);
            v = Vehicle.InDataVehicle(garage, Utilities.VType.Boat);
            c = Boat.InDataBoat();
            //garage.Add(new Boat(v[0], v[1], int.Parse(v[2]), decimal.Parse(v[3]), int.Parse(c[0]), int.Parse(c[1])));
            Console.WriteLine($"\n{Utilities.Line30}{Utilities.Line30}");
            Console.WriteLine($"{Utilities.Tab}{Text.LagtsTillGaraget}\n{garage.Last().ToString2(Utilities.VType.Boat)}");
            Console.WriteLine($"{Utilities.Line30}{Utilities.Line30}");
            Console.WriteLine($"{Utilities.Tab}{Utilities.Cap(Text.AntalFordon)}{garage.Count}{Text.Av}{garage.Capacity}{Text.platser}");
            Console.WriteLine($"{Utilities.Tab}{Text.TryckRetur}");
            Console.ReadLine();
        }
        public void AddAirplane(Garage<IVehicle> garage)
        {
            string[] v = new string[4];
            string[] c = new string[4];
            string Title = $"{Text.LaggTill} {Text.Flygplan}.";
            Utilities.ShowHeader(Title);
            v = Vehicle.InDataVehicle(garage, Utilities.VType.Airplane);
            //c = Airplane.InDataAirplane();
            //garage.Add(new Airplane(v[0], v[1], int.Parse(v[2]), decimal.Parse(v[3]), int.Parse(c[0]), int.Parse(c[1])));
            Console.WriteLine($"\n{Utilities.Line30}{Utilities.Line30}");
            Console.WriteLine($"{Utilities.Tab}{Text.LagtsTillGaraget}\n{garage.Last().ToString2(Utilities.VType.Airplane)}");
            Console.WriteLine($"{Utilities.Line30}{Utilities.Line30}");
            Console.WriteLine($"{Utilities.Tab}{Utilities.Cap(Text.AntalFordon)}{garage.Count}{Text.Av}{garage.Capacity}{Text.platser}");
            Console.WriteLine($"{Utilities.Tab}{Text.TryckRetur}");
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