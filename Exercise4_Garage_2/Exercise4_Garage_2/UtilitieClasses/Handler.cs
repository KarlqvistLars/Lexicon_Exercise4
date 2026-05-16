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
        public bool StartGarage(int garageSize = 0, bool populate = false)
        {
            if (garageSize <= 0)
                garageSize = 10;
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
            string[] v = new string[4];
            string[] c = new string[4];
            string Title = $"{Text.LaggTill} {type.ToString()}.";
            Utilities.ShowHeader(Title);
            v = Vehicle.InDataVehicle(garage, type);
            c = type switch
            {
                VType.Car => Car.InData(),
                VType.Bus => Bus.InData(),
                VType.Motorcycle => Motorcycle.InData(),
                VType.Boat => Boat.InData(),
                VType.Airplane => Airplane.InData(),
                _ => Array.Empty<string>()
            };
            garage.Add(type switch
            {
                VType.Car => new Car(v[0], v[1], int.Parse(v[2]), decimal.Parse(v[3]), int.Parse(c[0]), int.Parse(c[1])),
                VType.Bus => new Bus(v[0], v[1], int.Parse(v[2]), decimal.Parse(v[3]), int.Parse(c[0]), int.Parse(c[1])),
                VType.Motorcycle => new Motorcycle(v[0], v[1], int.Parse(v[2]), decimal.Parse(v[3]), int.Parse(c[0]), int.Parse(c[1])),
                VType.Boat => new Boat(v[0], v[1], int.Parse(v[2]), decimal.Parse(v[3]), decimal.Parse(c[0]), decimal.Parse(c[1]), decimal.Parse(c[2])),
                VType.Airplane => new Airplane(v[0], v[1], int.Parse(v[2]), decimal.Parse(v[3]), int.Parse(c[0]), decimal.Parse(c[1]), int.Parse(c[2])),
                _ => throw new ArgumentException("Invalid vehicle type")
            });
            Console.WriteLine($"\n{Utilities.Line30}{Utilities.Line30}");
            Console.WriteLine($"{Utilities.Tab}{Cap(type.ToString())} {Text.LagtsTillGaraget}\n{garage.Last().ToString2(type)}");
            Console.WriteLine($"{Utilities.Line30}{Utilities.Line30}");
            Console.WriteLine($"{Utilities.Tab}{Utilities.Cap(Text.AntalFordon)}{garage.Count}{Text.Av}{garage.Capacity}{Text.platser}");
            Console.WriteLine($"{Utilities.Tab}{Text.TryckRetur}");
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
        public void AddRandomVehicles(Garage<IVehicle> G, int count = 0)
        {
            string Title = "Lägg till slumpade fordon";
            List<string> randomRegNumbers = new List<string>();
            ShowHeader(Title);
            if (count == 0)
            {
                Console.Write($"{Tab}Hur många: ");
                count = int.TryParse(Console.ReadLine(), out int n) ? n : 0;
                if (count > G.Capacity - G.Count)
                {
                    count = G.Capacity - G.Count;
                    Console.WriteLine($"{Tab}Endast {count} fordon kan få plats.");
                    Console.WriteLine($"{Tab}Tryck Enter för att fortsätta...");
                    Console.ReadLine();
                }
            }
            for (int i = 0; i < count; i++)
            {
                Random random = new();
                int number = random.Next(1, 7);
                switch (number)
                {
                    case 1:
                        G.Add(new Car("ABC " + (i + 100).ToString(), "Röd", 1200, 4, 4, 4));
                        break;
                    case 2:
                        G.Add(new Bus("BBC " + (i + 100).ToString(), "Blå", 12000, 12, 48, 6));
                        break;
                    case 3:
                        G.Add(new Motorcycle("MCB " + (i + 100).ToString(), "Svart", 140, 2, 900, 2));
                        break;
                    case 4:
                        G.Add(new Boat("BA" + (i + 55020).ToString(), "Vit", 1200, 4, 2m, 24.6m, 1200));
                        break;
                    case 5:
                        G.Add(new Airplane(GenerateRandom(), "Silver", 15000, 20, 7000, 20, 28));
                        break;
                    case 6:
                        G.Add(new Motorcycle("MCC " + (i + 100).ToString(), "Rosa", 180, 2, 900, 3));
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"{Utilities.Tab}{count} st slumpade fordon har lagts till i garaget.");
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
            string input = Console.ReadLine()?.ToUpper() ?? string.Empty;
            foreach (var vehicle in garage)
            {
                if (vehicle.Uuid == input)
                {
                    garage.Remove(vehicle);
                    Console.WriteLine($"\n{Utilities.Line30}{Utilities.Line30}");
                    Console.WriteLine($"{Utilities.Tab}{Utilities.Cap(Text.FordonMedRegistrering)} {input} {Text.TogsBortGaraget}\n{vehicle.ToString2(vehicle.Type)}");
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
        public void ListVehicles(Garage<IVehicle> garage)
        {
            string Title = $"{Text.Rad3Main}.";
            Utilities.ShowHeader(Title);
            if (garage.Count == 0)
            {
                Console.WriteLine($"{Utilities.Tab}{"Tomt i garaget"}");
            }
            else
            {
                foreach (var vehicle in garage)
                {
                    Console.WriteLine(vehicle.ToString2(vehicle.Type));
                    Console.WriteLine($"{Utilities.Line30}{Utilities.Line30}");
                }
            }
            Console.WriteLine($"{Utilities.Tab}{Text.TryckRetur}");
            Console.ReadLine();
        }
    }
}