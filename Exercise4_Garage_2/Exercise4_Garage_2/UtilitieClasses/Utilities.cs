//#define TESTMODE
using Exercise4_Garage_2.MenuClasses;
using System.Text;
using System.Text.RegularExpressions;

namespace Exercise4_Garage_2
{
    static public class Utilities
    {
        public readonly static string Tab = new string(' ', 3);
        public readonly static string Line30 = new string('=', 30);
        readonly static int MenyHight = 10;
        public enum VType
        {
            None = 0,
            Car = 1,
            Bus = 2,
            Motorcycle = 3,
            Boat = 4,
            Airplane = 5
        }
        internal static string ShowMenu(string title, string[] options, string backOption)
        {
#if !TESTMODE
            Console.Clear();
#endif
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{Tab}* ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{Text.GarageVer}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" * ");
            Console.ResetColor();
            Console.WriteLine($"{Line30}{Line30}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Tab}{Cap(title)}");
            Console.ResetColor();
            Console.WriteLine($"{Line30}{Line30}");
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Cap(options[i])}");
            }
            Console.WriteLine($"0. {Cap(backOption)}");
            TomRaderMenu(MenyHight - options.Length - 1);
            Console.Write($"{Utilities.Tab}{Cap(MenuClasses.Text.Valg)}: ");
            string? input = Console.ReadLine();
            return input ?? string.Empty;
        }
        internal static void ShowHeader(string title)
        {
#if !TESTMODE
            Console.Clear();
#endif
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{Tab}* ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{Text.GarageVer}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" * ");
            Console.ResetColor();
            Console.WriteLine($"{Line30}{Line30}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Tab}{title}");
            Console.ResetColor();
            Console.WriteLine($"{Line30}{Line30}");
        }
        private static void TomRaderMenu(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine();
            }
        }
        public static string Cap(string text)
        {
            return string.IsNullOrEmpty(text)
                ? text
                : char.ToUpper(text[0]) + text[1..];
        }
        // 1.
        public static string ReadInput(Garage<IVehicle> garage, int type, VType vType, bool searchFlag = false)
        {
            string input, output = string.Empty;
            switch (type)
            {
                case 0: // RegNum
                    input = Console.ReadLine()?.ToUpper() ?? string.Empty;
                    output = InputRegNum(garage, input, vType);
                    break; // Color
                case 1:// Color
                    input = Console.ReadLine() ?? string.Empty;
                    output = InputColor(input, searchFlag);
                    break;
                case 2:// Vikt
                    input = Console.ReadLine() ?? string.Empty;
                    output = InputInteger(input, searchFlag);
                    break;
                case 3:// Längd
                    input = Console.ReadLine() ?? string.Empty;
                    output = InputDecimal(input, searchFlag);
                    break;
                case 4:// ??
                    input = Console.ReadLine() ?? string.Empty;
                    break;
                case 5:// ??
                    input = Console.ReadLine() ?? string.Empty;
                    break;
                default:
                    break;
            }
            return output;
        }
        // 2.4
        public static string InputDecimal(string input, bool searchFlag = false)
        {
            if (searchFlag && input == string.Empty) { return input; }
            do
            {
                if (decimal.TryParse(input, out decimal weight) && weight > 0)
                {
                    return weight.ToString();
                }
                else
                {
                    Console.WriteLine($"{Tab}Ogiltigt format. \n{Tab}Ange ett positivt decimaltal.");
                    Console.Write($"{Tab}Försök igen: ");
                    input = Console.ReadLine() ?? string.Empty;
                }
            } while (true);
        }
        // 2.3
        public static string InputInteger(string input, bool searchFlag = false)
        {
            if (searchFlag && input == string.Empty) { return input; }
            do
            {
                if (int.TryParse(input, out int weight) && weight > 0)
                {
                    return weight.ToString();
                }
                else
                {
                    Console.WriteLine($"{Tab}Ogiltigt format. \n{Tab}Ange ett positivt heltal.");
                    Console.Write($"{Tab}Försök igen: ");
                    input = Console.ReadLine() ?? string.Empty;
                }
            } while (true);
        }
        // 2.2
        private static string InputColor(string input, bool searchFlag = false)
        {
            if (searchFlag && input == string.Empty) { return input; }
            do
            {
                switch (input)
                {
                    case "1":
                        return "Röd";
                    case "2":
                        return "Blå";
                    case "3":
                        return "Grön";
                    case "4":
                        return "Gul";
                    case "5":
                        return "Svart";
                    default:
                        Console.WriteLine($"{Tab}Ogiltigt färgval.\n{Tab}Ange en siffra mellan 1 och 5 för att välja en färg.");
                        Console.Write($"{Tab}Försök igen: ");
                        input = Console.ReadLine() ?? string.Empty;
                        break;
                }
            } while (true);
        }
        // 2.1
        public static string InputRegNum(Garage<IVehicle> garage, string regNum, VType type, bool skipUniqCheck = false)
        {
            bool running = true;
            string[] RegNumCheck = new string[3];
            do
            {
                RegNumCheck = ReadRegnumInput(type, regNum);
                regNum = RegNumCheck[2] ?? regNum;
                if (RegNumCheck[0] == "true")
                {
                    if (garage.Count == 0)
                    {
                        running = false;
                        return regNum;
                    }
                    foreach (var item in garage)
                    {
                        if (skipUniqCheck || item.Uuid != regNum)
                        {
                            running = false;
                            return regNum;
                        }
                        else
                        {
                            Console.Write($"{Tab}Registreringsnumret finns redan i garaget.\n{Tab}Ange ett unikt registreringsnummer: ");
                            regNum = Console.ReadLine().ToUpper() ?? string.Empty;
                        }
                    }
                }
                else
                {
                    Console.WriteLine(RegNumCheck[1]);
                    Console.Write($"{Tab}Försök igen: ");
                    regNum = Console.ReadLine().ToUpper() ?? string.Empty;
                }
            }
            while (running);
            return regNum;
        }
        // 3.
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
                        result[2] = regNumber;
                    }
                    else
                    {
                        result[1] = $"{Tab}Ogiltigt registreringsnummer. \n{Tab}Formatet för bil ska vara 3 bokstäver följt av 3 siffror (exempel: ABC 123).";
                    }
                    break;
                case VType.Bus:
                    if (Regex.IsMatch(regNumber ?? string.Empty, @"^[A-Z]{3} [0-9]{3}$"))
                    {
                        result[0] = "true";
                        result[2] = regNumber;
                    }
                    else
                    {
                        result[1] = $"{Tab}Ogiltigt registreringsnummer. \n{Tab}Formatet för buss ska vara 3 bokstäver följt av 3 siffror (exempel: ABC 123).";
                    }
                    break;
                case VType.Motorcycle:
                    if (Regex.IsMatch(regNumber ?? string.Empty, @"^[A-Z]{3} [0-9]{3}$"))
                    {
                        result[0] = "true";
                        result[2] = regNumber;
                    }
                    else
                    {
                        result[1] = $"{Tab}Ogiltigt registreringsnummer. \n{Tab}Formatet för motorcykel ska vara 3 bokstäver följt av 3 siffror (exempel: ABC 123).";
                    }
                    break;
                case VType.Boat:
                    if (Regex.IsMatch(regNumber ?? string.Empty, @"^[A-Z]{2}[0-9]{5}$"))
                    {
                        result[0] = "true";
                        result[2] = regNumber;
                    }
                    else
                    {
                        result[1] = $"{Tab}Ogiltigt registreringsnummer. \n{Tab}Formatet för båt ska vara 2 bokstäver följt av 5 siffror (exempel: AB12345).";
                    }
                    break;
                case VType.Airplane:
                    if (Regex.IsMatch(regNumber ?? string.Empty, @"SE-[A-Z]{3}$"))
                    {
                        result[0] = "true";
                        result[2] = regNumber;
                    }
                    else
                    {
                        result[1] = $"{Tab}Ogiltigt registreringsnummer. \n{Tab}Formatet för flygplan ska vara SE- följt av 3 bokstäver (exempel: SE-ABC).";
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
        public static string GenerateRandom()
        {
            Random random = new Random();
            string letter = "SE-";
            for (int i = 0; i < 3; i++)
            {
                letter += (((char)random.Next('A', 'Z' + 1)).ToString());
            }
            return letter;
        }
        public static (string, Garage<IVehicle>) NavigateToOpen(Garage<IVehicle> garage, string path = "")
        {
            bool valid = false;
            string Title = Text.ValjFil;
            ShowHeader(Title);
            Handler handler = new Handler();
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            (valid, currentDirectory) = InputValgBibliotek(currentDirectory, 1);
            var content = Directory.GetDirectories(currentDirectory);
            do
            {
                ShowHeader(Title);
                string shortpath = "";
                if (currentDirectory.Length > 50)
                {
                    shortpath = ShortenPath(currentDirectory);
                }
                else
                {
                    shortpath = currentDirectory;
                }
                Console.WriteLine($"{Tab}{Text.FilesIn}{Text.CurrentDir}:\n{Tab}{shortpath}\n{Line30}{Line30}");
                FileInfo[] files = new DirectoryInfo(currentDirectory).GetFiles();
                bool hasFiles = files.Length > 0;
                foreach (var file in files)
                {
                    if (file.Name.Contains(".txt"))
                    {
                        Console.WriteLine($"{Tab}{file.Name}");
                    }
                }
                Console.WriteLine($"{Line30}{Line30}");
                if (hasFiles)
                {
                    Console.Write($"{Tab}{Utilities.Cap(Text.ValgDassaFiler)}?");
                    string choice = Console.ReadLine();
                    if (choice.ToUpper() == "Y")
                    {
                        Title = Text.ValjFil;
                        ShowHeader(Title);
                        FileInfo[] choosefile = new DirectoryInfo(currentDirectory).GetFiles();
                        FileInfo[] fileNames = new FileInfo[choosefile.Length];
                        int indexFil = 1;
                        foreach (var file in choosefile)
                        {
                            if (file.Name.Contains(".txt"))
                            {
                                Console.WriteLine($"{indexFil}. {file.Name}");
                                fileNames[indexFil - 1] = file;
                                indexFil++;
                            }
                        }
                        Console.WriteLine($"{Line30}{Line30}");
                        Console.Write($"{Utilities.Tab}{Text.ValjFil}: ");
                        string fileChoise = Console.ReadLine();
                        string pathToOpen = Path.Combine(currentDirectory, fileNames[int.Parse(fileChoise) - 1].Name).ToString();
                        var result = handler.LoadVehicles(garage, pathToOpen);
                        return result;
                    }
                }
                Console.WriteLine($"\n{Utilities.Tab}{Cap(Text.CurrentDir)}: \n{Utilities.Tab}{Utilities.ShortenPath(currentDirectory)}");
                int index = 2;
                Console.WriteLine($"1.  .\\");
                foreach (var item in content)
                {
                    Console.WriteLine($"{index}.   {item.ToString().Replace(currentDirectory, "")}");
                    index++;
                }
                Console.WriteLine($"0. ..\\");
                Console.WriteLine($"{Utilities.Tab}{Text.ValjBibliotek}: ");
                int open = int.TryParse(Console.ReadLine(), out int op) ? op : -1;

                (valid, currentDirectory) = InputValgBibliotek(currentDirectory, open);
                content = Directory.GetDirectories(currentDirectory);
            } while (true);
        }
        public static (string, Garage<IVehicle>) NavigateToSave(Garage<IVehicle> garage, string path = "")
        {
            string Title = Text.Rad1LoadVehicleFromFilePart2;
            ShowHeader(Title);
            Handler handler = new Handler();
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var (valid, newDirectory) = InputValgBibliotek(currentDirectory, 1);

            var content = Directory.GetDirectories(newDirectory);
            do
            {
                FileInfo[] files = new DirectoryInfo(currentDirectory).GetFiles();
                bool hasFiles = files.Length > 0;
                content = Directory.GetDirectories(currentDirectory);
                int index = 2;
                Console.WriteLine($"1.  .\\");
                foreach (var item in content)
                {
                    Console.WriteLine($"{index}.   {item.ToString().Replace(currentDirectory, "")}");
                    index++;
                }
                Console.WriteLine($"0. ..\\");
                Console.WriteLine($"{Line30}{Line30}");
                Console.Write($"{Utilities.Tab}{Text.ValjBibliotek}: ");
                int open = int.TryParse(Console.ReadLine(), out int op) ? op : -1;
                ShowHeader(Title);
                (valid, currentDirectory) = InputValgBibliotek(currentDirectory, open);
                if (valid)
                {
                    Console.WriteLine($"{Utilities.Tab}{ShortenPath(currentDirectory)}");
                    Console.Write($"{Tab}Spara i denna katalog(Y/N el.Enter)?");
                    if (Console.ReadLine().ToUpper() == "Y")
                    {
                        Console.WriteLine($"{Line30}{Line30}");
                        Console.Write($"{Tab}Ange filnamn (utan .txt): ");
                        string fileName = Console.ReadLine();
                        path = Path.Combine(currentDirectory, fileName + ".txt");
                        Handler.SaveVehicles(garage, path);
                        break;
                    }
                    Console.WriteLine($"{Line30}{Line30}");
                }
            } while (true);
            return (path, garage);
        }
        internal static string ShortenPath(string currentDirectory)
        {
            int startL = currentDirectory.Length;
            int maxL = 50;
            StringBuilder sb = new StringBuilder();
            if (startL > maxL)
            {
                sb.Append(currentDirectory.Substring(0, 25) + "..." + currentDirectory.Substring(startL - 25 > 0 ? startL - 25 : 0, 25));
            }
            else
            {
                sb.Append(currentDirectory);
            }
            return sb.ToString();
        }
        private static (bool, string) InputValgBibliotek(string currentDirectory, int open)
        {
            var content = Directory.GetDirectories(currentDirectory);
            if (open == 1) { return (true, currentDirectory); }
            else if (open == 0)
            {
                DirectoryInfo current = new DirectoryInfo(currentDirectory);
                if (current.Parent != null)
                {
                    current = current.Parent;
                }
                return (true, current.FullName);
            }
            else if (open == -1 || open > content.Length + 1)
            {
                ShowHeader(Text.ValjFil);
                Console.WriteLine($"{Utilities.Tab}Ogiltigt val, försök igen.");
                Console.WriteLine($"{Line30}{Line30}");
                return (false, new DirectoryInfo(currentDirectory).FullName);
            }
            else { return (true, content[open - 2]); }
        }
    }
}
