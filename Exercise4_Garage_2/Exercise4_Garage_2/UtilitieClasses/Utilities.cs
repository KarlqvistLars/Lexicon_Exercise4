//#define TESTMODE
using System.Text;
using System.Text.RegularExpressions;

namespace Exercise3.UtilitesClasses
{
    static public class Utilities
    {
        static public string line30 { get; } = "==============================";
        static public string vTab { get; } = "   ";
        public enum VType
        {
            None = 0,
            Car = 1,
            Bus = 2,
            Motorcycle = 3,
            Boat = 4,
            Airplane = 5
        }

        public static string InputRegNum(Garage G, VType type, bool skipUniqCheck = false)
        {
            bool running = true;
            string[] RegNumCheck = new string[3];
            bool isUniq = false;
            string regNum = Console.ReadLine().ToUpper() ?? string.Empty;
            do
            {
                RegNumCheck = ReadRegnumInput(type, regNum);
                isUniq = CheckUniqNumber(G, regNum, skipUniqCheck);
                regNum = RegNumCheck[2];

                if ((RegNumCheck[0] == "true" && isUniq) || string.IsNullOrEmpty(regNum))
                {
                    running = false;
                }
                else
                {
                    if (skipUniqCheck)
                    {
                        running = false;
                    }
                    else
                    {
                        Console.WriteLine(RegNumCheck[1]);
                        Console.Write($"{vTab}Försök igen: ");
                        regNum = Console.ReadLine().ToUpper() ?? string.Empty;
                    }
                }
            }
            while (running);
            return regNum;
        }
        /// <summary>
        /// Ett filter för att validera registreringsnummer baserat på fordonstypen. Använder regex för att kontrollera formatet.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="regNumber"></param>
        /// <returns></returns>
        public static string[] ReadRegnumInput(VType type, string regNumber)
        {
            string[] result = new string[3];
            result[0] = "false";
            switch (type)
            {
                case VType.Car:
                    if (Regex.IsMatch(regNumber ?? string.Empty, @"^[A-Z]{3} [0-9]{3}$"))
                    {
                        result[0] = "true";
                    }
                    else
                    {
                        result[1] = $"{vTab}Ogiltigt registreringsnummer. \n{vTab}Formatet för bil ska vara 3 bokstäver följt av 3 siffror (exempel: ABC 123).";
                    }
                    break;
                case VType.Bus:
                    if (Regex.IsMatch(regNumber ?? string.Empty, @"^[A-Z]{3} [0-9]{3}$"))
                    {
                        result[0] = "true";
                    }
                    else
                    {
                        result[1] = $"{vTab}Ogiltigt registreringsnummer. \n{vTab}Formatet för buss ska vara 3 bokstäver följt av 3 siffror (exempel: ABC 123).";
                    }
                    break;
                case VType.Motorcycle:
                    if (Regex.IsMatch(regNumber ?? string.Empty, @"^[A-Z]{3} [0-9]{3}$"))
                    {
                        result[0] = "true";
                    }
                    else
                    {
                        result[1] = $"{vTab}Ogiltigt registreringsnummer. \n{vTab}Formatet för motorcykel ska vara 3 bokstäver följt av 3 siffror (exempel: ABC 123).";
                    }
                    break;
                case VType.Boat:
                    if (Regex.IsMatch(regNumber ?? string.Empty, @"^[A-Z]{2}[0-9]{5}$"))
                    {
                        result[0] = "true";
                    }
                    else
                    {
                        result[1] = $"{vTab}Ogiltigt registreringsnummer. \n{vTab}Formatet för båt ska vara 2 bokstäver följt av 5 siffror (exempel: AB12345).";
                    }
                    break;
                case VType.Airplane:
                    if (Regex.IsMatch(regNumber ?? string.Empty, @"SE-[A-Z]{3}$"))
                    {
                        result[0] = "true";
                    }
                    else
                    {
                        result[1] = $"{vTab}Ogiltigt registreringsnummer. \n{vTab}Formatet för flygplan ska vara SE- följt av 3 bokstäver (exempel: SE-ABC).";
                    }
                    break;
                default:
                    if ((Regex.IsMatch(regNumber ?? string.Empty, @"SE-[A-Z]{3}$")) || (Regex.IsMatch(regNumber ?? string.Empty, @"^[A-Z]{2}[0-9]{5}$")) || (Regex.IsMatch(regNumber ?? string.Empty, @"^[A-Z]{3} [0-9]{3}$")))
                    {
                        result[2] = regNumber;
                    }
                    break;
            }
            return result;
        }
        internal static string GenerateRandom()
        {
            Random random = new Random();

            //string[] colors = { "Röd", "Blå", "Grön", "Svart", "Vit", "Gul", "Silver" };

            string letter = "SE-";
            int number = random.Next(1, 26);
            for (int i = 0; i < 3; i++)
            {
                letter += (((char)random.Next('A', 'Z' + 1)).ToString());
            }
            return letter;
        }
        internal static void ListNumberOf(Garage garage, int val)
        {
            VType type = (VType)val;
            int count = 0;
            for (int i = 0; i < garage.Vehicles.Length; i++)
            {
                if (garage.Vehicles[i] != null)
                {
                    if (type.ToString() == garage.Vehicles[i].Type)
                    {
                        Console.WriteLine(garage.Vehicles[i].Type + " nr: " + garage.Vehicles[i].Uuid);
                        count++;
                    }
                }
            }
            Console.WriteLine("Total number of " + type.ToString() + ": " + count);
        }
        /// <summary>
        /// Returnerar false om det redan finns ett fordon med samma registreringsnummer i garaget, annars true. 
        /// Kan overridea för att tillåta dubbletter (används vid redigering av fordon där
        /// registreringsnumret inte ändras).
        /// </summary>
        /// <param name="garage"></param>
        /// <param name="regNumber"></param>
        /// <param name="overRide"></param>Default false. Man vill stoppa möjligheten att använda detta nummer.
        /// <returns></returns>
        internal static bool CheckUniqNumber(Garage garage, string? regNumber, bool overRide = false)
        {
            bool output = true;
            for (int i = 0; i < garage.Vehicles.Length; i++)
            {
                if (garage.Vehicles[i]?.Uuid?.ToString() == regNumber?.ToString() && !overRide) // ?.ToString() added to avoid possible null reference exception
                {
                    output = false;
                    Console.WriteLine($"{vTab}Registreringsnummer finns redan.");
                }
            }
            return output;
        }
        internal static void ShowHeader(string title)
        {
#if !TESTMODE
            Console.Clear();
#endif
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{vTab}* ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Garage 1.0");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" * ");
            Console.ResetColor();
            Console.WriteLine($"{line30}{line30}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{vTab}{title}");
            Console.ResetColor();
            Console.WriteLine($"{line30}{line30}");
        }
        public static void SaveVehicles(Garage garage, string filePath)
        {
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                File.Create(filePath).Close();
            }
            StringBuilder sb = new();
            sb.AppendLine($"GarageCapacity:{garage.Capacity}");
            foreach (var vehicle in garage.Vehicles)
            {
                if (vehicle != null)
                {
                    switch (vehicle.Type)
                    {
                        case "Car":
                            sb.AppendLine($"Type:Car;Uuid:{vehicle.Uuid};Color:{vehicle.Color};Weight:{vehicle.Weight};Length:{vehicle.Length}{((Car)vehicle).ToStringTypeSpec()}");
                            break;
                        case "Bus":
                            sb.AppendLine($"Type:Bus;Uuid:{vehicle.Uuid};Color:{vehicle.Color};Weight:{vehicle.Weight};Length:{vehicle.Length}{((Bus)vehicle).ToStringTypeSpec()}");
                            break;
                        case "Motorcycle":
                            sb.AppendLine($"Type:Motorcycle;Uuid:{vehicle.Uuid};Color:{vehicle.Color};Weight:{vehicle.Weight};Length:{vehicle.Length}{((Motorcycle)vehicle).ToStringTypeSpec()}");
                            break;
                        case "Boat":
                            sb.AppendLine($"Type:Boat;Uuid:{vehicle.Uuid};Color:{vehicle.Color};Weight:{vehicle.Weight};Length:{vehicle.Length}{((Boat)vehicle).ToStringTypeSpec()}");
                            break;
                        case "Airplane":
                            sb.AppendLine($"Type:Airplane;Uuid:{vehicle.Uuid};Color:{vehicle.Color};Weight:{vehicle.Weight};Length:{vehicle.Length}{((Airplane)vehicle).ToStringTypeSpec()}");
                            break;
                        default:
                            break;
                    }
                }
            }
            File.WriteAllText(filePath, sb.ToString());
            sb.Clear();
        }
        public static string LoadVehicles(Garage garage, string filePath)
        {
            if (!File.Exists(filePath)) { return $"{Utilities.vTab}{filePath} existerar ej inga fordon har laddats."; }
            var lines = File.ReadAllLines(filePath);
            int capacity = int.Parse(lines[0].Split(':')[1]);

            Vehicle[] vehicles = garage.Vehicles;

            Garage garageLoading = new Garage(capacity);
            int vehicleCount = 0;
            foreach (var line in lines)
            {
                Vehicle v = new();
                if (string.IsNullOrWhiteSpace(line)) { continue; }
                var vehicleParts = line.Split('[');
                var parts = vehicleParts[0].Split(';');
                if (parts.Length < 4) { continue; }
                var type = parts[0].Split(':')[1].Trim();
                var uuid = parts[1].Split(':')[1].Trim();
                var color = parts[2].Split(':')[1].Trim();
                var weight = int.Parse(parts[3].Split(':')[1].Trim());
                var length = int.Parse(parts[4].Split(':')[1].Trim());
                //Console.WriteLine($"Comm[{type}][{uuid}][{color}][{weight}][{length}]");
                var specificData = vehicleParts[1].Trim(']');
                //Console.WriteLine($"Spec[{specificData}]");
                switch (type)
                {
                    case "Car":
                        var carData = specificData.Split(';');
                        var wheels = (carData[0].Split(':')[1].Trim());
                        var numberOfDoors = int.Parse(carData[1].Split(':')[1].Trim(']'));
                        //Console.WriteLine($"Spec[{wheels}][{numberOfDoors}]");
                        v = new Car(uuid, color, weight, length, numberOfDoors, int.TryParse(wheels, out int cw) ? cw : 0);
                        break;
                    case "Bus":
                        var busData = specificData.Split(';');
                        var busWheels = (busData[0].Split(':')[1].Trim());
                        var busSeats = int.Parse(busData[1].Split(':')[1].Trim(']'));
                        //Console.WriteLine($"Spec[{busWheels}][{busSeats}]");
                        v = new Bus(uuid, color, weight, length, busSeats, int.TryParse(busWheels, out int bw) ? bw : 0);
                        break;
                    case "Motorcycle":
                        var motoData = specificData.Split(';');
                        var motoWheels = (motoData[0].Split(':')[1].Trim());
                        var cubicInch = int.Parse(motoData[1].Split(':')[1].Trim(']'));
                        //Console.WriteLine($"Spec[{motoWheels}][{cubicInch}]");
                        v = new Motorcycle(uuid, color, weight, length, cubicInch, int.TryParse(motoWheels, out int mw) ? mw : 0);
                        break;
                    case "Boat":
                        var boatData = specificData.Split(';');
                        var maxDepth = boatData[0].Split(':')[1].Trim();
                        var maxSpeed = boatData[1].Split(':')[1].Trim(']');
                        var deplacement = boatData[2].Split(':')[1].Trim(']');
                        //Console.WriteLine($"Spec[{maxDepth}][{maxSpeed}][{deplacement}]");
                        v = new Boat(uuid, color, weight, length, decimal.TryParse(maxDepth, out decimal md) ? md : 0, decimal.TryParse(maxSpeed, out decimal msp) ? msp : 0, decimal.TryParse(deplacement, out decimal d) ? d : 0);
                        break;
                    case "Airplane":
                        var planeData = specificData.Split(';');
                        var planeLiftCapacity = planeData[0].Split(':')[1].Trim(']');
                        var planeWingspan = planeData[1].Split(':')[1].Trim();
                        var planePax = planeData[2].Split(':')[1].Trim();
                        //Console.WriteLine($"Spec[{planeLiftCapacity}][{planeWingspan}][{planePax}]");
                        v = new Airplane(uuid, color, weight, length, int.TryParse(planeLiftCapacity, out int lc) ? lc : 0, decimal.TryParse(planeWingspan, out decimal ws) ? ws : 0, int.TryParse(planePax, out int pax) ? pax : 0);
                        break;
                    default:
                        break;
                }
                garageLoading.AddVehicle(v);
                vehicleCount++;
            }

            MenuHandler.garage = garageLoading;
            return $"{Utilities.vTab}{vehicleCount} st fordon har laddats från {filePath}.\n{Utilities.vTab}Tryck Enter för att fortsätta...";
        }
    }
}
