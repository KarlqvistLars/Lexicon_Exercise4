using Exercise4_Garage_2.Interfaces;
using Exercise4_Garage_2.MenuClasses;
using Exercise4_Garage_2.VehicleClasses;
using System.Text;
using static Exercise4_Garage_2.Utilities;

namespace Exercise4_Garage_2 {
    /// <summary>
    /// Handler-klassen är service klass till [Garage.cs] och ansvarar för att hantera alla operationer relaterade till garaget och fordonen. 
    /// Den innehåller metoder för att starta garaget, lägga till fordon, ta bort fordon, söka och filtrera fordon, samt spara och ladda fordon från en fil. 
    /// Den fungerar som en central punkt för all logik som rör garaget och dess innehåll, 
    /// och interagerar med användaren genom konsolen för att utföra dessa operationer.
    /// </summary>
    public class Handler : IHandler {
        public Handler() { }
        Garage<IVehicle> garage = new Garage<IVehicle>(1);

        static string path = Environment.GetCommandLineArgs()[0];
        public static string GetInstallationPath() {
            return Path.GetDirectoryName(path);
        }
        public bool StartGarage(int garageSize = 0, bool populate = false) {
            string installationPath = GetInstallationPath();

            if (garageSize <= 0) {
                ShowHeader("Välkommen till garaget 2.0!");
                Console.Write($"\n{Utilities.Tab}Tryck Enter för standardstorlek 20,\n{Utilities.Tab}eller välj en storlek för garaget: ");
                garageSize = int.TryParse(Console.ReadLine(), out int size) ? size : 0;
                Console.Write($"\n{Utilities.Tab}Vill du starta med ett fullt garage? (Y/N): ");
                string startFull = Console.ReadLine();
                if (startFull?.ToUpper() == "Y") {
                    populate = true;
                }
                if (garageSize <= 0)
                    garageSize = 20;
            }
            if (populate == false) {
                garage = new Garage<IVehicle>(garageSize);
                UI.MenuMain(garage);
            } else {
                garage = new Garage<IVehicle>(garageSize);
                AddStartVehicles(garage, garageSize);
                UI.MenuMain(garage);
            }
            return true;
        }
        public void AddVehicle(Garage<IVehicle> garage, VType type) {
            string[] v = new string[4];
            string[] c = new string[4];
            string Title = $"{Text.LaggTill} {type.ToString()}.";
            Utilities.ShowHeader(Title);
            v = Vehicle.InDataVehicle(garage, type);
            c = type switch {
                VType.Car => Car.InData(),
                VType.Bus => Bus.InData(),
                VType.Motorcycle => Motorcycle.InData(),
                VType.Boat => Boat.InData(),
                VType.Airplane => Airplane.InData(),
                _ => Array.Empty<string>()
            };
            garage.Add(type switch {
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
            Console.WriteLine($"{Utilities.Tab}{Utilities.Cap(Text.AntalFordon)} {garage.Count}{Text.Av}{garage.Capacity}{Text.platser}");
            Console.WriteLine($"{Utilities.Tab}{Text.TryckRetur}");
            Console.ReadLine();
        }
        public void AddRandomVehicles(Garage<IVehicle> G, int count = 0) {
            string Title = $"{Text.LaggTill} {Text.SlumpadeFordon}";
            List<string> randomRegNumbers = new List<string>();
            ShowHeader(Title);
            if (count == 0) {
                Console.Write($"{Tab}{Text.HurManga}: ");
                count = int.TryParse(Console.ReadLine(), out int n) ? n : 0;
                if (count > G.Capacity - G.Count) {
                    count = G.Capacity - G.Count;
                    Console.WriteLine($"{Tab}Endast {count} {Text.FordonKanFaPlats}.");
                    Console.WriteLine($"{Tab}{Text.TryckRetur}");
                    Console.ReadLine();
                }
            }
            for (int i = 0; i < count; i++) {
                Random random = new();
                int number = random.Next(1, 7);
                switch (number) {
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
            Console.WriteLine($"{Utilities.Tab}{count} {Text.SlumpadeFordonHarLagtsTillIGaraget}");
            Console.WriteLine($"{Utilities.Tab}{Text.TryckRetur}");
            Console.ReadLine();
        }
        internal void AddStartVehicles(Garage<IVehicle> garage, int count) {
            AddRandomVehicles(garage, count);
        }
        public void RemoveVehicle(Garage<IVehicle> garage) {
            string Title = $"{Utilities.Cap(Text.Rad1RemoveVehicle)}.";
            Utilities.ShowHeader(Title);
            var (result, filteredGarage) = SeachAndFilterVehicles(garage);
            if (result) {
                Console.Write($"\n{Utilities.Tab}{Utilities.Cap(Text.TaBortFordon)} med listnr: ");
                int input = int.TryParse(Console.ReadLine(), out int n) ? n : 0;
                string reg = SelectRegnr(filteredGarage, input);
                if ((filteredGarage != null && filteredGarage.Count <= 0) || input <= 0 || input > filteredGarage.Count) {
                    Console.WriteLine($"{Utilities.Tab}{Utilities.Cap(Text.FelaktigInput)}.");
                    Console.WriteLine($"{Utilities.Tab}{Text.TryckRetur}");
                    Console.ReadLine();
                    return;
                }
                var vehicleToRemove = filteredGarage[input - 1];
                string regnr = vehicleToRemove.Uuid;
                if (RemoveFromGarageList(garage, regnr)) {
                    Console.WriteLine($"{Utilities.Tab}{Utilities.Cap(Text.FordonMedRegistrering)} {regnr} {Text.HarTagitsBort}.");
                } else {
                    Console.WriteLine($"{Utilities.Tab}{Utilities.Cap(Text.FordonMedRegistrering)} {regnr} {Text.HittadesEj}.");
                }
            } else {
                Console.WriteLine($"{Utilities.Tab}{Utilities.Cap(Text.HittadesEj)}.");
                Console.WriteLine($"{Utilities.Tab}{Text.TryckRetur}");
                Console.ReadLine();
            }
            Console.ReadLine();
        }
        private bool RemoveFromGarageList(Garage<IVehicle> garage, string regnr) {
            var enumerator = garage.GetEnumerator();
            while (enumerator.MoveNext()) {
                if (enumerator.Current.Uuid.Equals(regnr, StringComparison.OrdinalIgnoreCase)) {
                    garage.Remove(enumerator.Current);
                    return true;
                }
            }
            return false;
        }
        private string SelectRegnr(Garage<IVehicle> garage, int input) {
            int c = 0;
            string regnr = string.Empty;
            var enumerator = garage.GetEnumerator();
            while (enumerator.MoveNext()) {
                if (c == input - 1) {
                    enumerator.Current.ToString2(enumerator.Current.Type);
                    regnr = enumerator.Current.Uuid;
                }
                c++;
            }
            return regnr;
        }
        public void RemoveVehicleRegNum(Garage<IVehicle> garage) {
            string Title = $"{Utilities.Cap(Text.Rad2RemoveVehicle)}.";
            Utilities.ShowHeader(Title);
            Console.Write($"\n{Utilities.Tab}{Utilities.Cap(Text.TaBortFordon)} {Text.medRegistrering}: ");
            bool notFound = true;
            string input = Console.ReadLine()?.ToUpper() ?? string.Empty;
            foreach (var vehicle in garage) {
                if (vehicle.Uuid == input) {
                    garage.Remove(vehicle);
                    Console.WriteLine($"\n{Utilities.Line30}{Utilities.Line30}");
                    Console.WriteLine($"{Utilities.Tab}{Utilities.Cap(Text.FordonMedRegistrering)} {input} {Text.TogsBortGaraget}\n{vehicle.ToString2(vehicle.Type)}");
                    Console.WriteLine($"{Utilities.Line30}{Utilities.Line30}");
                    notFound = false;
                    break;
                }
            }
            if (notFound) {
                Console.WriteLine($"\n{Utilities.Line30}{Utilities.Line30}");
                Console.WriteLine($"{Utilities.Tab}{Text.FordonMedRegistrering} {input} {Text.HittadesEj}");
                Console.WriteLine($"{Utilities.Line30}{Utilities.Line30}");
            }
            Console.WriteLine($"{Utilities.Tab}{Text.TryckRetur}");
            Console.ReadLine();
        }
        public static (bool, Garage<IVehicle>) ListVehicles(Garage<IVehicle> garage) {
            bool listNotEmpty = false;
            Garage<IVehicle> garageFiltered = new Garage<IVehicle>(garage.Count);
            string Title = $"{Utilities.Cap(Text.Rad3Main)}.";
            Utilities.ShowHeader(Title);
            if (garage.Count == 0) {
                Console.WriteLine($"{Utilities.Tab}{"Tomt i garaget"}");
                listNotEmpty = false;
            } else {
                int counting = 1;
                foreach (var vehicle in garage) {
                    Console.WriteLine($"{Utilities.Tab}{counting}.\n{vehicle.ToString2(vehicle.Type)}");
                    Console.WriteLine($"{Utilities.Line30}{Utilities.Line30}");
                    garageFiltered.Add(vehicle);
                    counting++;
                }
                listNotEmpty = true;
            }
            return (listNotEmpty, garageFiltered);
        }
        public (bool, Garage<IVehicle>) FindVehicleByRegNumber(Garage<IVehicle> garage) {
            string Title = $"{Utilities.Cap(Text.Rad3Main)}.";
            Utilities.ShowHeader(Title);
            Console.Write($"\n{Utilities.Tab}{Utilities.Cap(Text.Rad3Main)} {Text.medRegistrering}: ");
            string input = Console.ReadLine()?.ToUpper() ?? string.Empty;
            bool notFound = true;
            foreach (var vehicle in garage) {
                if (vehicle.Uuid == input) {
                    Console.WriteLine($"\n{Utilities.Line30}{Utilities.Line30}");
                    Console.WriteLine($"{Utilities.Tab}{Utilities.Cap(Text.FordonMedRegistrering)} {input} {Text.Hittades}");
                    Console.WriteLine($"{Utilities.Line30}{Utilities.Line30}");
                    Console.WriteLine(vehicle.ToString2(vehicle.Type));
                    Console.WriteLine($"{Utilities.Line30}{Utilities.Line30}");
                    notFound = false;
                    break;
                }
            }
            if (notFound) {
                Console.WriteLine($"\n{Utilities.Line30}{Utilities.Line30}");
                Console.WriteLine($"{Utilities.Tab}{Utilities.Cap(Text.FordonMedRegistrering)} {input} {Text.HittadesEj}");
                Console.WriteLine($"{Utilities.Line30}{Utilities.Line30}");
            }
            Console.WriteLine($"{Utilities.Tab}{Text.TryckRetur}");
            Console.ReadLine();
            return (true, garage);
        }
        public (bool, Garage<IVehicle>) SeachAndFilterVehicles(Garage<IVehicle> garage) {
            string Title = $"{Utilities.Cap(Text.Rad3ShowVehicle)}.";
            Utilities.ShowHeader(Title);
            Console.WriteLine($"{Utilities.Tab}{$"{Text.SokOchFiltrera}"}");
            Console.Write($"{Utilities.Tab}{$"{Text.VillDuSokaEfter}"}? ");
            int typeInput = int.TryParse(Console.ReadLine(), out int t) ? t : 0;
            VType type = typeInput switch {
                1 => VType.Car,
                2 => VType.Bus,
                3 => VType.Motorcycle,
                4 => VType.Boat,
                5 => VType.Airplane,
                _ => VType.None
            };
            string[] ve = Vehicle.InDataVehicle(garage, type, true);
            Console.WriteLine($"\n{Utilities.Line30}{Utilities.Line30}");

            var result = ShowGarageSearch(garage, type, ve[0].Length > 0 ? ve[0] : string.Empty, ve[1].Length > 1 ? ve[1] : string.Empty, ve[2].Length > 0 ? int.Parse(ve[2]) : 0, ve[3].Length > 0 ? decimal.Parse(ve[3]) : 0);
            return result;
        }
        private (bool, Garage<IVehicle>) ShowGarageSearch(Garage<IVehicle> garage, VType vT, string regNumber, string color, int weight, decimal length) {
            if (garage == null) {
                Console.WriteLine($"{Utilities.Tab}Garaget är tomt.");
                return (false, garage);
            }
            Garage<IVehicle> filteredGarage = new Garage<IVehicle>(garage.Capacity);
            foreach (Vehicle v in garage) {
                if (v != null && (vT == VType.None || v.Type == vT) &&
                    (string.IsNullOrEmpty(regNumber) || v.Uuid == regNumber) &&
                    (string.IsNullOrEmpty(color) || v.Color == color) &&
                    (weight == 0 || v.Weight == weight) &&
                    (length == 0 || v.Length == length)) {
                    filteredGarage.Add(v);
                }
            }
            return ListVehicles(filteredGarage);
        }
        public bool OgitigtVal() {
            System.Console.WriteLine($"{Utilities.Tab}Ogiltigt val");
            Console.ReadKey();
            return true;
        }
        public static void SaveVehicles(Garage<IVehicle> garage, string FullfilePath) {
            if (!File.Exists(FullfilePath)) {
                Directory.CreateDirectory(Path.GetDirectoryName(FullfilePath));
                File.Create(FullfilePath).Close();
            }
            StringBuilder sb = new();
            sb.AppendLine($"GarageCapacity:{garage.Capacity}");
            foreach (var vehicle in garage) {
                if (vehicle != null) {
                    switch (vehicle.Type) {
                        case VType.Car:
                            sb.AppendLine($"Type:Car;Uuid:{vehicle.Uuid};Color:{vehicle.Color};Weight:{vehicle.Weight};Length:{vehicle.Length}{((Car)vehicle).ToStringTypeSpec()}");
                            break;
                        case VType.Bus:
                            sb.AppendLine($"Type:Bus;Uuid:{vehicle.Uuid};Color:{vehicle.Color};Weight:{vehicle.Weight};Length:{vehicle.Length}{((Bus)vehicle).ToStringTypeSpec()}");
                            break;
                        case VType.Motorcycle:
                            sb.AppendLine($"Type:Motorcycle;Uuid:{vehicle.Uuid};Color:{vehicle.Color};Weight:{vehicle.Weight};Length:{vehicle.Length}{((Motorcycle)vehicle).ToStringTypeSpec()}");
                            break;
                        case VType.Boat:
                            sb.AppendLine($"Type:Boat;Uuid:{vehicle.Uuid};Color:{vehicle.Color};Weight:{vehicle.Weight};Length:{vehicle.Length}{((Boat)vehicle).ToStringTypeSpec()}");
                            break;
                        case VType.Airplane:
                            sb.AppendLine($"Type:Airplane;Uuid:{vehicle.Uuid};Color:{vehicle.Color};Weight:{vehicle.Weight};Length:{vehicle.Length}{((Airplane)vehicle).ToStringTypeSpec()}");
                            break;
                        default:
                            break;
                    }
                }
            }
            Console.WriteLine($"{Utilities.Tab}Sparar fordon till \n{FullfilePath}");
            Console.ReadKey();
            File.WriteAllText(FullfilePath, sb.ToString());
            sb.Clear();
        }
        public (string, Garage<IVehicle>) LoadVehicles(Garage<IVehicle> garage, string filePath) {

            if (!File.Exists(filePath)) { return ($"{Utilities.Tab}{filePath} existerar ej inga fordon har laddats.", garage); }

            var lines = File.ReadAllLines(filePath);
            int vehicleCount = 0;
            string output = "";
            try {
                int capacity = int.Parse(lines[0].Split(':')[1]);

                IVehicle[] vehicles = garage.Vehicles;

                Garage<IVehicle> garageLoading = new Garage<IVehicle>(capacity);
                foreach (var line in lines) {
                    IVehicle v = new Vehicle();
                    if (string.IsNullOrWhiteSpace(line)) { continue; }
                    var vehicleParts = line.Split('[');
                    var parts = vehicleParts[0].Split(';');
                    if (parts.Length < 4) { continue; }
                    var type = parts[0].Split(':')[1].Trim();
                    var uuid = parts[1].Split(':')[1].Trim();
                    var color = parts[2].Split(':')[1].Trim();
                    var weight = int.Parse(parts[3].Split(':')[1].Trim());
                    var length = int.Parse(parts[4].Split(':')[1].Trim());
                    var specificData = vehicleParts[1].Trim(']');
                    switch (type) {
                        case "Car":
                            var carData = specificData.Split(';');
                            var wheels = (carData[0].Split(':')[1].Trim());
                            var numberOfDoors = int.Parse(carData[1].Split(':')[1].Trim(']'));
                            v = new Car(uuid, color, weight, length, numberOfDoors, int.TryParse(wheels, out int cw) ? cw : 0);
                            break;
                        case "Bus":
                            var busData = specificData.Split(';');
                            var busWheels = (busData[0].Split(':')[1].Trim());
                            var busSeats = int.Parse(busData[1].Split(':')[1].Trim(']'));
                            v = new Bus(uuid, color, weight, length, busSeats, int.TryParse(busWheels, out int bw) ? bw : 0);
                            break;
                        case "Motorcycle":
                            var motoData = specificData.Split(';');
                            var motoWheels = (motoData[0].Split(':')[1].Trim());
                            var cubicInch = int.Parse(motoData[1].Split(':')[1].Trim(']'));
                            v = new Motorcycle(uuid, color, weight, length, cubicInch, int.TryParse(motoWheels, out int mw) ? mw : 0);
                            break;
                        case "Boat":
                            var boatData = specificData.Split(';');
                            var maxDepth = boatData[0].Split(':')[1].Trim();
                            var maxSpeed = boatData[1].Split(':')[1].Trim(']');
                            var deplacement = boatData[2].Split(':')[1].Trim(']');
                            v = new Boat(uuid, color, weight, length, decimal.TryParse(maxDepth, out decimal md) ? md : 0, decimal.TryParse(maxSpeed, out decimal msp) ? msp : 0, decimal.TryParse(deplacement, out decimal d) ? d : 0);
                            break;
                        case "Airplane":
                            var planeData = specificData.Split(';');
                            var planeLiftCapacity = planeData[0].Split(':')[1].Trim(']');
                            var planeWingspan = planeData[1].Split(':')[1].Trim();
                            var planePax = planeData[2].Split(':')[1].Trim();
                            v = new Airplane(uuid, color, weight, length, int.TryParse(planeLiftCapacity, out int lc) ? lc : 0, decimal.TryParse(planeWingspan, out decimal ws) ? ws : 0, int.TryParse(planePax, out int pax) ? pax : 0);
                            break;
                        default:
                            break;
                    }
                    garageLoading.Add(v);
                    vehicleCount++;
                }
                garage = garageLoading;

            } catch (Exception) {

            }
            output = $"{vehicleCount} st {Text.VehicleLodedFrom}: \n{Utilities.Tab}{Utilities.ShortenPath(filePath)}.\n{Utilities.Tab}{Text.TryckRetur}";
            return (output, garage);
        }
    }
}