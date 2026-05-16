using Exercise4_Garage_2.Interfaces;
using Exercise4_Garage_2.MenuClasses;
using Exercise4_Garage_2.VehicleClasses;
using static Exercise4_Garage_2.Utilities;

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
        //public void AddVehicles(Garage<IVehicle> garage, VType type)  
        public void AddVehicle(Garage<IVehicle> garage, VType type)
        {
            string Title = "Lägg till fordon";
            //ShowHeader(Title);
            Console.WriteLine($"{Utilities.Tab}Tryck på valfri tangent för att återgå till huvudmenyn...");
            Console.ReadLine();
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
            Console.WriteLine($"{Utilities.Tab}{Cap(Text.Bil)} {Text.LagtsTillGaraget}\n{garage.Last().ToString2(Utilities.VType.Car)}");
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
            Console.WriteLine($"{Utilities.Tab}{Cap(Text.Buss)} {Text.LagtsTillGaraget}\n{garage.Last().ToString2(Utilities.VType.Bus)}");
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
            c = Motorcycle.InData(garage);
            garage.Add(new Motorcycle(v[0], v[1], int.Parse(v[2]), decimal.Parse(v[3]), int.Parse(c[0]), int.Parse(c[1])));
            Console.WriteLine($"\n{Utilities.Line30}{Utilities.Line30}");
            Console.WriteLine($"{Utilities.Tab}{Cap(Text.Motorcykel)} {Text.LagtsTillGaraget}\n{garage.Last().ToString2(Utilities.VType.Motorcycle)}");
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
            c = Boat.InData();
            garage.Add(new Boat(v[0], v[1], int.Parse(v[2]), decimal.Parse(v[3]), decimal.Parse(c[0]), decimal.Parse(c[1]), decimal.Parse(c[2])));
            Console.WriteLine($"\n{Utilities.Line30}{Utilities.Line30}");
            Console.WriteLine($"{Utilities.Tab}{Cap(Text.Boat)} {Text.LagtsTillGaraget}\n{garage.Last().ToString2(Utilities.VType.Boat)}");
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
            c = Airplane.InData();
            garage.Add(new Airplane(v[0], v[1], int.Parse(v[2]), decimal.Parse(v[3]), int.Parse(c[0]), decimal.Parse(c[1]), int.Parse(c[2])));
            Console.WriteLine($"\n{Utilities.Line30}{Utilities.Line30}");
            Console.WriteLine($"{Utilities.Tab}{Vehicle.Cap(VType.Airplane.ToString())}{Text.LagtsTillGaraget}\n{garage.Last().ToString2(Utilities.VType.Airplane)}");
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
        public void RemoveVehicle(Garage<IVehicle> garage) { Console.WriteLine($"{Utilities.Tab}Tryck på valfri tangent för att återgå till huvudmenyn..."); Console.ReadLine(); }
        public void RemoveVehicleRegNum(Garage<IVehicle> garage)
        {
            string Title = $"{Utilities.Cap(Text.TaBortFordon)}.";
            Utilities.ShowHeader(Title);
            Console.Write($"\n{Utilities.Tab}{Utilities.Cap(Text.TaBortFordon)} {Text.medRegistrering}: ");
            bool notFound = true;
            string input = Console.ReadLine() ?? string.Empty;
            foreach (var vehicle in garage)
            {
                if (vehicle.Uuid == input)
                {
                    garage.Remove(vehicle);
                    Console.WriteLine($"\n{Utilities.Line30}{Utilities.Line30}");
                    Console.WriteLine($"{Utilities.Tab}{Utilities.Cap(vehicle.Type)} {Text.TogsBortGaraget}\n{vehicle.ToString2()}");
                    Console.WriteLine($"{Utilities.Line30}{Utilities.Line30}");
                    notFound = false;
                    break;
                }
            }
            if (notFound)
            {
                Console.WriteLine($"\n{Utilities.Line30}{Utilities.Line30}");
                Console.WriteLine($"{Utilities.Tab}{Text.FordonMedRegistrering} {input} {Text.HittadesEj}");
                Console.WriteLine($"{Utilities.Line30}{Utilities.Line30}");
            }
            Console.WriteLine($"{Utilities.Tab}{Text.TryckRetur}");
            Console.ReadLine();
        }
    }
}