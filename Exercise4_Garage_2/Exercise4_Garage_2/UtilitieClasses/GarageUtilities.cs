using static Exercise3.UtilitesClasses.Utilities;

namespace Exercise3.UtilitesClasses
{
    public class GarageUtilities
    {
        /// <summary>
        /// Alla menyer under "Lägg till fordon".
        /// </summary>
        internal static void AddCar(Garage G)
        {
            string Title = "Lägg till Bil...";
            ShowHeader(Title);
            Console.Write($"{vTab}Registreringsnummer: ");
            string regNum = InputRegNum(G, VType.Car);
            Console.Write($"{vTab}Färg: ");
            string? color = Console.ReadLine();
            Console.Write($"{vTab}Vikt: ");
            int weight = int.TryParse(Console.ReadLine(), out int w) ? w : 0;
            Console.Write($"{vTab}Längd: ");
            int length = int.TryParse(Console.ReadLine(), out int l) ? l : 0;
            Console.Write($"{vTab}Antal dörrar: ");
            int doors = int.TryParse(Console.ReadLine(), out int d) ? d : 0;
            Vehicle vehicle = new Car(regNum.ToUpper(), color ?? string.Empty, weight, length, 4, doors);
            if (string.IsNullOrEmpty(regNum))
            {
                Console.WriteLine($"{vTab}Inget registreringsnummer tillagt. Detta fordon har lagts till i garaget.\n{vTab}Tryck Retur för att fortsätta...");
                Console.ReadLine();
                return;
            }
            G.AddVehicle(vehicle);
            Console.WriteLine(vehicle.ToString2());
            Console.WriteLine($"{vTab}Denna bil har lagts till i garaget.\n{vTab}Tryck Retur för att fortsätta...");
            Console.ReadLine();
        }
        internal static void AddBus(Garage G)
        {
            string Title = "Lägg till Buss";
            ShowHeader(Title);
            Console.Write($"{vTab}Registreringsnummer: ");
            string regNum = InputRegNum(G, VType.Bus);
            Console.Write($"{vTab}Färg: ");
            string? color = Console.ReadLine();
            Console.Write($"{vTab}Vikt: ");
            int weight = int.TryParse(Console.ReadLine(), out int w) ? w : 0;
            Console.Write($"{vTab}Längd: ");
            int length = int.TryParse(Console.ReadLine(), out int l) ? l : 0;
            Console.Write($"{vTab}Antal säten: ");
            int seats = int.TryParse(Console.ReadLine(), out int s) ? s : 0;
            Vehicle vehicle = new Bus(regNum, color ?? string.Empty, weight, length, seats, 6);
            if (string.IsNullOrEmpty(regNum))
            {
                Console.WriteLine($"{vTab}Inget registreringsnummer tillagt. Detta fordon har lagts till i garaget.\n{vTab}Tryck Retur för att fortsätta...");
                Console.ReadLine();
                return;
            }
            G.AddVehicle(vehicle);
            Console.WriteLine(vehicle.ToString2());
            Console.WriteLine($"{vTab}Denna buss har lagts till i garaget.\n{vTab}Tryck Retur för att fortsätta...");
            Console.ReadLine();
        }
        internal static void AddMotorcycle(Garage G)
        {
            string Title = $" Lägg till MC";
            ShowHeader(Title);
            Console.Write($"{vTab}Registreringsnummer: ");
            string regNum = InputRegNum(G, VType.Motorcycle);
            Console.Write($"{vTab}Färg: ");
            string? color = Console.ReadLine();
            Console.Write($"{vTab}Vikt: ");
            int weight = int.TryParse(Console.ReadLine(), out int w) ? w : 0;
            Console.Write($"{vTab}Längd: ");
            int length = int.TryParse(Console.ReadLine(), out int l) ? l : 0;
            Console.Write($"{vTab}Motorstorlek: ");
            int engineSize = int.TryParse(Console.ReadLine(), out int e) ? e : 0;
            Vehicle vehicle = new Motorcycle(regNum, color ?? string.Empty, weight, length, engineSize, 2);
            if (string.IsNullOrEmpty(regNum))
            {
                Console.WriteLine($"{vTab}Inget registreringsnummer tillagt. Detta fordon har lagts till i garaget.\n{vTab}Tryck Retur för att fortsätta...");
                Console.ReadLine();
                return;
            }
            G.AddVehicle(vehicle);
            Console.WriteLine(vehicle.ToString2());
            Console.WriteLine($"{vTab}Denna MC har lagts till i garaget.\n{vTab}Tryck Retur för att fortsätta...");
            Console.ReadLine();
        }
        internal static void AddBoat(Garage G)
        {
            string Title = $"Lägg till Båt";
            ShowHeader(Title);
            Console.Write($"{vTab}Registreringsnummer: ");
            string regNum = InputRegNum(G, VType.Boat);
            Console.Write($"{vTab}Färg: ");
            string? color = Console.ReadLine();
            Console.Write($"{vTab}Vikt: ");
            int weight = int.TryParse(Console.ReadLine(), out int w) ? w : 0;
            Console.Write($"{vTab}Längd: ");
            int length = int.TryParse(Console.ReadLine(), out int l) ? l : 0;
            Console.Write($"{vTab}Max vattendjup: ");
            int maxDepth = int.TryParse(Console.ReadLine(), out int d) ? d : 0;
            Console.Write($"{vTab}Max hastighet: ");
            int maxSpeed = int.TryParse(Console.ReadLine(), out int s) ? s : 0;
            Console.Write($"{vTab}Deplacement: ");
            int deplacement = int.TryParse(Console.ReadLine(), out int depl) ? depl : 0;
            Vehicle vehicle = new Boat(regNum, color ?? string.Empty, weight, length, maxDepth, maxSpeed, deplacement);
            if (string.IsNullOrEmpty(regNum))
            {
                Console.WriteLine($"{vTab}Inget registreringsnummer tillagt. Detta fordon har lagts till i garaget.\n{vTab}Tryck Retur för att fortsätta...");
                Console.ReadLine();
                return;
            }
            G.AddVehicle(vehicle);
            Console.WriteLine(vehicle.ToString2());
            Console.WriteLine($"{vTab}Denna båt har lagts till i garaget.\n{vTab}Tryck Retur för att fortsätta...");
            Console.ReadLine();
        }
        internal static void AddAirplane(Garage G)
        {
            string Title = $"Lägg till FLP";
            ShowHeader(Title);
            Console.Write($"{vTab}Registreringsnummer: ");
            string regNum = InputRegNum(G, VType.Airplane);
            Console.Write($"{vTab}Färg: ");
            string? color = Console.ReadLine();
            Console.Write($"{vTab}Vikt: ");
            int weight = int.TryParse(Console.ReadLine(), out int w) ? w : 0;
            Console.Write($"{vTab}Längd: ");
            int length = int.TryParse(Console.ReadLine(), out int l) ? l : 0;
            Console.Write($"{vTab}Vingbredd: ");
            int wSpan = int.TryParse(Console.ReadLine(), out int ws) ? ws : 0;
            Console.Write($"{vTab}Lyftkapacitet: ");
            int liftCapacity = int.TryParse(Console.ReadLine(), out int lc) ? lc : 0;
            Console.Write($"{vTab}Antal passagerare: ");
            int passengers = int.TryParse(Console.ReadLine(), out int p) ? p : 0;
            Vehicle vehicle = new Airplane(regNum, color ?? string.Empty, weight, length, liftCapacity, wSpan, passengers);
            if (string.IsNullOrEmpty(regNum))
            {
                Console.WriteLine($"{vTab}Inget registreringsnummer tillagt. Detta fordon har lagts till i garaget.\n{vTab}Tryck Retur för att fortsätta...");
                Console.ReadLine();
                return;
            }
            G.AddVehicle(vehicle);
            Console.WriteLine(vehicle.ToString2());
            Console.WriteLine($"{vTab}Detta flygplan har lagts till i garaget.\n{vTab}Tryck Retur för att fortsätta...");
            Console.ReadLine();
        }
        internal static void AddRandomVehicles(Garage G, int count = 0)
        {
            string Title = "Lägg till slumpade fordon";
            List<string> randomRegNumbers = new List<string>();
            ShowHeader(Title);
            int countNok = 0;
            if (count == 0)
            {
                Console.Write($"{vTab}Hur många: ");
                count = int.TryParse(Console.ReadLine(), out int n) ? n : 0;
            }
            for (int i = 0; i < count; i++)
            {
                Random random = new();
                int number = random.Next(1, 7);
                bool isAddedOk = false;
                switch (number)
                {
                    case 1:
                        isAddedOk = G.AddVehicle(new Car("ABC " + (i + 100).ToString(), "Röd", 1200, 4, 4, 4));
                        break;
                    case 2:
                        isAddedOk = G.AddVehicle(new Bus("BBC " + (i + 100).ToString(), "Blå", 12000, 12, 48, 6));
                        break;
                    case 3:
                        isAddedOk = G.AddVehicle(new Motorcycle("MCB " + (i + 100).ToString(), "Svart", 140, 2, 900, 2));
                        break;
                    case 4:
                        isAddedOk = G.AddVehicle(new Boat("BA" + (i + 55020).ToString(), "Vit", 1200, 4, 2m, 24.6m, 1200));
                        break;
                    case 5:
                        isAddedOk = G.AddVehicle(new Airplane(GenerateRandom(), "Silver", 15000, 20, 7000, 20, 28));
                        break;
                    case 6:
                        isAddedOk = G.AddVehicle(new Motorcycle("MCC " + (i + 100).ToString(), "Rosa", 180, 2, 900, 3));
                        break;
                    default:
                        break;
                }
                if (!isAddedOk)
                {
                    countNok++;
                    //Console.WriteLine(vehicle.ToString2());
                }

            }
            Console.WriteLine($"{vTab}{count - countNok} st slumpade fordon har lagts till i garaget.");
            Console.WriteLine($"{vTab}Tryck på valfri tangent för att återgå till huvudmenyn...");
            Console.ReadLine();
        }
        internal static void AddStartVehicles(int count)
        {
            AddRandomVehicles(MenuHandler.garage != null ? MenuHandler.garage : throw new InvalidOperationException($"{vTab}Garage is not initialized."), count);
        }
        /// <summary>
        /// Alla menyer under "Ta bort fordon".
        /// </summary>
        internal static void RemoveVehicle(Garage G)
        {
            string Title = "Ta bort fordon.";
            ShowHeader(Title);
            if (NewSearchVehicle(G)) { RemoveVehicleById(G); }
        }
        internal static void RemoveVehicleByRegnummer(Garage G)
        {
            string Title = $"Ta bort fordon på Regnummer";
            ShowHeader(Title);
            RemoveVehicleById(G);
        }
        internal static void RemoveVehicleById(Garage G)
        {
            Console.Write($"{vTab}Välj fordons regnr. att ta bort: ");
            string? regNumber = Console.ReadLine()?.ToUpper();
            if (CheckUniqNumber(G, regNumber, true))
            {
                G.RemoveVehicle(regNumber ?? string.Empty);
                Console.WriteLine($"{vTab}Fordonet med registreringsnummer {regNumber} har tagits bort.");
            }
            Console.WriteLine($"{vTab}Tryck på valfri tangent för att återgå till huvudmenyn...");
            Console.ReadKey();
        }
        /// <summary>
        /// Alla menyer under "Visa fordon".
        /// </summary>
        internal static void ShowAllVehicles(Garage G)
        {
            bool fordonVisade = false;
            string Title = "Visa alla fordon av";
            ShowHeader(Title);
            Console.WriteLine($"{vTab}Tryck tangen för att fortsätta...");
            Console.ReadKey();
            int count = 0;
            for (int i = 0; i < G.Vehicles.Length; i++)
            {
                count++;
                string text = $"{count} {line30}";
                text = text.Length > 30 ? text[..30] : text;
                if (G.Vehicles[i]?.Uuid != null)
                {
                    Console.WriteLine($"{text}{line30}");
                    Console.WriteLine($"{G.Vehicles[i].ToString2()}");
                    fordonVisade = true;
                }
                else
                {
                    count--;
                }
            }
            if (!fordonVisade)
            {
                Console.WriteLine($"{vTab}Inga fordon hittades.\n{vTab}Garaget är tomt.");
            }
            Console.WriteLine($"{line30}{line30}\n{vTab}Tryck på valfri tangent för att återgå till huvudmenyn...");
            Console.ReadKey();
        }
        internal static void ShowVehicleById(Garage garage)
        {
            ShowHeader("Visa fordon på regnr");
            Console.Write($"{vTab}Ange regnr: ");
            string? regNumber = Console.ReadLine() ?? string.Empty;
            foreach (Vehicle v in garage?.Vehicles ?? new Vehicle[0])
            {
                if (v != null && v.Uuid != null && v.Uuid.Equals(regNumber, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{line30}{line30}");
                    Console.WriteLine(v.ToString());
                    Console.WriteLine($"{line30}{line30}");
                    Console.WriteLine($"{vTab}Tryck på valfri tangent för att återgå till huvudmenyn...");
                    Console.ReadKey();
                    return;
                }
            }
            Console.WriteLine($"{vTab}Inget fordon hittades.");
            Console.WriteLine($"{vTab}Tryck på valfri tangent för att återgå till huvudmenyn...");
            Console.ReadKey();
        }
        //internal static bool SearchVehicleAndShow(Garage garage)
        //{
        //    bool fordonVisade = false;
        //    string[] fordon = { "fordon", "bilar", "bussar", "motorcyklar", "båtar", "flygplan" };
        //    string Title = "Sök fordon";
        //    ShowHeader(Title);
        //    Console.WriteLine("Sök parametrar:\n" +
        //        "Välj en siffra, skriv en sökterm eller\ntryck Enter för att hoppa över:");
        //    Console.Write("Du vill söka en:\n1. Bil\n2. Buss\n3. Motorcykel\n4. Båt\n5. Flygplan?\nAnge val: ");
        //    int vehichleType = int.TryParse(Console.ReadLine(), out int res) ? res : 0;
        //    Console.Write($"\nDu söker {fordon[vehichleType]} med registrerings nummer (Enter för att hoppa över): ");
        //    string regNumber = string.Empty;
        //    //bool isValid = true;
        //    //do
        //    //{
        //    //    regNumber = Console.ReadLine() ?? string.Empty;
        //    //    isValid = Utilities.ReadRegnumInput((Utilities.VType)vehichleType, regNumber);
        //    //    if (Utilities.CheckUniqNumber(garage, regNumber))
        //    //    {
        //    //        Console.WriteLine($"{Utilities.vTab}Det finns redan ett fordon med detta registreringsnummer.\n{Utilities.vTab}Försök igen:");
        //    //        isValid = false;

        //    //    }
        //    //} while (!isValid);


        //    Console.Write("\nsom har färgen (Enter för att hoppa över): ");
        //    string? color = Console.ReadLine() ?? string.Empty;
        //    Console.Write("\noch väger (Enter för att hoppa över): ");
        //    string? weight = Console.ReadLine() ?? string.Empty;
        //    Console.Write("\nmed längden (Enter för att hoppa över): ");
        //    string? length = Console.ReadLine() ?? string.Empty;
        //    fordonVisade = ShowGarageSearch(garage, (VType)vehichleType, regNumber, color, weight, length);
        //    Console.WriteLine($"\n{vTab}Tryck på Enter för att fortsätta...");
        //    Console.ReadLine();
        //    return fordonVisade;
        //}
        internal static bool SearchVehicle(Garage garage)
        {
            bool fordonVisade = false;
            string[] fordon = { "fordon", "bilar", "bussar", "motorcyklar", "båtar", "flygplan" };
            string Title = "Sök fordon";
            ShowHeader(Title);
            Console.WriteLine("Sök parametrar:\n" +
                "Välj en siffra, skriv en sökterm eller\ntryck Enter för att hoppa över:");
            Console.Write("Du vill söka en:\n1. Bil\n2. Buss\n3. Motorcykel\n4. Båt\n5. Flygplan?\nAnge val: ");
            int vehichleType = int.TryParse(Console.ReadLine(), out int res) ? res : 0;

            Console.Write($"\nDu söker {fordon[vehichleType]} med registrerings nummer (Enter för att hoppa över): ");

            string regNumber = Utilities.InputRegNum(garage, (Utilities.VType)vehichleType, true);
            //string regNumber = Utilities.InputRegNum(garage, (Utilities.VType)vehichleType, false);

            Console.Write("\nsom har färgen (Enter för att hoppa över): ");
            string? color = Console.ReadLine() ?? string.Empty;
            Console.Write("\noch väger (Enter för att hoppa över): ");
            string? weight = Console.ReadLine() ?? string.Empty;
            Console.Write("\nmed längden (Enter för att hoppa över): ");
            string? length = Console.ReadLine() ?? string.Empty;
            fordonVisade = ShowGarageSearch(garage, (VType)vehichleType, regNumber, color, weight, length);
            return fordonVisade;
        }
        private static bool ShowGarageSearch(Garage G, VType vT, string regNumber, string color, string weight, string length)
        {
            int counter = 0;
            bool listExist = false;
            string[] fordon = { "fordon", "bilar", "bussar", "motorcyklar", "båtar", "flygplan" };
            foreach (Vehicle v in G.Vehicles)
            {
                if (string.IsNullOrEmpty(regNumber))
                {
                    if (v != null &&
                        (vT == VType.None || v.Type.Equals(vT.ToString(), StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(color) || v.Color.Equals(color, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(weight) || v.Weight.ToString().Equals(weight, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(length) || v.Length.ToString().Equals(length, StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.WriteLine($"{line30}{line30}");
                        Console.WriteLine(v.ToString2());
                        listExist = true;
                        counter++;
                    }
                }
                else if (v != null && v.Uuid.Equals(regNumber, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{line30}{line30}");
                    Console.WriteLine(v.ToString2());
                    listExist = true;
                    counter++;
                }
            }
            Console.WriteLine($"{line30}{line30}");
            Console.WriteLine($"{vTab}Det fanns {counter} {fordon[(int)vT]} som matchade sökkriterierna.");
            Console.WriteLine($"{vTab}Regnummer: {(string.IsNullOrEmpty(regNumber) ? "Alla" : regNumber)}, Färg: {(string.IsNullOrEmpty(color) ? "Alla" : color)}, Vikt: {(string.IsNullOrEmpty(weight) ? "Alla" : weight)}, Längd: {(string.IsNullOrEmpty(length) ? "Alla" : length)}");
            if (!listExist)
            {
                Console.WriteLine($"{vTab}Det fanns inga {fordon[(int)vT]} som matchade sökkriterierna.");
                Console.WriteLine($"{vTab}Regnummer: {(string.IsNullOrEmpty(regNumber) ? "Alla" : regNumber)}, Färg: {(string.IsNullOrEmpty(color) ? "Alla" : color)}, Vikt: {(string.IsNullOrEmpty(weight) ? "Alla" : weight)}, Längd: {(string.IsNullOrEmpty(length) ? "Alla" : length)}");
            }
            return listExist;
        }

        internal static bool NewSearchVehicle(Garage garage)
        {
            bool fordonVisade = false;
            string[] fordon = { "fordon", "bilar", "bussar", "motorcyklar", "båtar", "flygplan" };
            string Title = "Sök fordon";
            ShowHeader(Title);
            Console.WriteLine("Sök parametrar:\n" +
                "Välj en siffra, skriv en sökterm eller\ntryck Enter för att hoppa över:");
            Console.Write("Du vill söka en:\n1. Bil\n2. Buss\n3. Motorcykel\n4. Båt\n5. Flygplan?\nAnge val: ");
            int vehichleType = int.TryParse(Console.ReadLine(), out int res) ? res : 0;

            Console.Write($"\nDu söker {fordon[vehichleType]} med registrerings nummer (Enter för att hoppa över): ");

            string regNumber = Utilities.InputRegNum(garage, (Utilities.VType)vehichleType, true);
            //string regNumber = Utilities.InputRegNum(garage, (Utilities.VType)vehichleType, false);

            Console.Write("\nsom har färgen (Enter för att hoppa över): ");
            string? color = Console.ReadLine() ?? string.Empty;
            Console.Write("\noch väger (Enter för att hoppa över): ");
            string? weight = Console.ReadLine() ?? string.Empty;
            Console.Write("\nmed längden (Enter för att hoppa över): ");
            string? length = Console.ReadLine() ?? string.Empty;
            fordonVisade = NewShowGarageSearch(garage, (VType)vehichleType, regNumber, color, weight, length);
            return fordonVisade;
        }

        private static bool NewShowGarageSearch(Garage G, VType vT, string regNumber, string color, string weight, string length)
        {
            int counter = 0;
            bool listExist = false;
            string[] fordon = { "fordon", "bilar", "bussar", "motorcyklar", "båtar", "flygplan" };

            Vehicle[] searchType = new Vehicle[G.Capacity];
            Vehicle[] searchReg = new Vehicle[G.Capacity];
            Vehicle[] searchColor = new Vehicle[G.Capacity];
            Vehicle[] searchWeight = new Vehicle[G.Capacity];
            Vehicle[] searchLength = new Vehicle[G.Capacity];

            for (int i = 0; i < G.Capacity; i++)
            {
                if (G.Vehicles[i]?.Type != null && (vT == VType.None || G.Vehicles[i]?.Type == vT.ToString()))
                {
                    searchType[i] = G.Vehicles[i];
                }
            }
            for (int i = 0; i < G.Capacity; i++)
            {
                if (searchType[i]?.Uuid != null && (string.IsNullOrEmpty(regNumber) || searchType[i]?.Uuid == regNumber?.ToString()))
                {
                    searchReg[i] = searchType[i];
                }
            }
            for (int i = 0; i < G.Capacity; i++)
            {
                if (searchReg[i]?.Color != null && (string.IsNullOrEmpty(color) || searchReg[i]?.Color == color))
                {
                    searchColor[i] = searchReg[i];
                }
            }
            for (int i = 0; i < G.Capacity; i++)
            {
                if (searchColor[i]?.Weight != null && (string.IsNullOrEmpty(weight) || searchColor[i]?.Weight.ToString() == weight))
                {
                    searchWeight[i] = searchColor[i];
                }
            }
            for (int i = 0; i < G.Capacity; i++)
            {
                if (searchWeight[i]?.Length != null && (string.IsNullOrEmpty(length) || searchWeight[i]?.Length.ToString() == length))
                {
                    searchLength[i] = searchWeight[i];
                }
            }


            foreach (var item in searchLength)
            {

                if (item != null)
                {
                    Console.WriteLine($"{line30}{line30}");
                    Console.WriteLine(item.ToString2());
                    listExist = true;
                    counter++;
                }
            }

            Console.WriteLine($"{line30}{line30}");
            Console.WriteLine($"{vTab}Det fanns {counter} {fordon[(int)vT]} som matchade sökkriterierna.");
            Console.WriteLine($"{vTab}Regnummer: {(string.IsNullOrEmpty(regNumber) ? "Alla" : regNumber)}, Färg: {(string.IsNullOrEmpty(color) ? "Alla" : color)}, Vikt: {(string.IsNullOrEmpty(weight) ? "Alla" : weight)}, Längd: {(string.IsNullOrEmpty(length) ? "Alla" : length)}");
            if (!listExist)
            {
                Console.WriteLine($"{vTab}Det fanns inga {fordon[(int)vT]} som matchade sökkriterierna.");
                Console.WriteLine($"{vTab}Regnummer: {(string.IsNullOrEmpty(regNumber) ? "Alla" : regNumber)}, Färg: {(string.IsNullOrEmpty(color) ? "Alla" : color)}, Vikt: {(string.IsNullOrEmpty(weight) ? "Alla" : weight)}, Längd: {(string.IsNullOrEmpty(length) ? "Alla" : length)}");
            }
            return listExist;
        }

    }
}
