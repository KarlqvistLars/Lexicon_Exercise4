//#define TESTMODE
namespace Exercise4_Garage_2
{
    static public class Utilities
    {
        public readonly static string Tab = new string(' ', 3);
        readonly static string Line30 = new string('=', 30);
        readonly static int MenyHight = 10;
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
            Console.Write($"{Utilities.Tab}{Cap(MenuClasses.Text.Valg)}");
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
    }
}
