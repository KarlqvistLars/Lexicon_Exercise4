//#define TESTMODE
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
            Console.Write("Garage 2.0");
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
            Console.Write("Garage 1.0");
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
        public static string ReadInput(Garage<IVehicle> garage, int type, VType vType)
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
                    output = InputString(input);
                    break;
                case 2:// Vikt
                    input = Console.ReadLine() ?? string.Empty;
                    output = InputInteger(input);
                    break;
                case 3:// Längd
                    input = Console.ReadLine() ?? string.Empty;
                    output = InputDecimal(input);
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
        public static string InputDecimal(string input)
        {
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
        public static string InputInteger(string input)
        {
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
        private static string InputString(string input)
        {
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
                            Console.WriteLine($"{Tab}Registreringsnumret finns redan i garaget.\n{Tab}Ange ett unikt registreringsnummer: ");
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

            //string[] colors = { "Röd", "Blå", "Grön", "Svart", "Vit", "Gul", "Silver" };

            string letter = "SE-";
            int number = random.Next(1, 26);
            for (int i = 0; i < 3; i++)
            {
                letter += (((char)random.Next('A', 'Z' + 1)).ToString());
            }
            return letter;
        }
    }
}
