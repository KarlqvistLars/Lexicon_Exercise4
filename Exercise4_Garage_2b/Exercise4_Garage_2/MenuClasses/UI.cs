using Exercise4_Garage_2b.Interfaces;
using Exercise4_Garage_2b.MenuClasses;
using System.Globalization;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Exercise4_Garage_2b.Tests")]
namespace Exercise4_Garage_2b {
    public class UI : IUI {
        private static bool Running { get; set; } = true;
        static string[] menuTextMain = new string[] { };
        static string[] menuTextAdd = new string[] { };
        static string[] menuTextRemove = new string[] { };
        static string[] menuTextShow = new string[] { };
        static string[] menuLoadFromFile = new string[] { };
        static string[] menuTextLanguage = new string[] { };
        private static Handler Handler = new Handler();
        public static void LoadMenuText() {
            menuTextMain = new string[]
            {
                Utilities.Cap(Text.Rad1Main),
                Utilities.Cap(Text.Rad2Main),
                Utilities.Cap(Text.Rad3Main),
                Utilities.Cap(Text.Rad4Main),
                Utilities.Cap(Text.Rad5Main)
            };
            menuTextAdd = new string[]
            {
                Utilities.Cap(Text.Rad1AddVehicle),
                Utilities.Cap(Text.Rad2AddVehicle),
                Utilities.Cap(Text.Rad3AddVehicle),
                Utilities.Cap(Text.Rad4AddVehicle),
                Utilities.Cap(Text.Rad5AddVehicle),
                Utilities.Cap(Text.Rad6AddVehicle)
            };
            menuTextRemove = new string[]
            {
                Utilities.Cap(Text.Rad1RemoveVehicle),
                Utilities.Cap(Text.Rad2RemoveVehicle),
            };
            menuTextShow = new string[]
            {
                Utilities.Cap(Text.Rad1ShowVehicle),
                Utilities.Cap(Text.Rad2ShowVehicle),
                Utilities.Cap(Text.Rad3ShowVehicle)
            };
            menuLoadFromFile = new string[]
            {
                Utilities.Cap(Text.Rad1LoadVehicleFromFilePart1),
                Utilities.Cap(Text.Rad1LoadVehicleFromFilePart2),
            };
            menuTextLanguage = new string[]
            {
                Utilities.Cap(Text.Rad1ChooseLanguage),
                Utilities.Cap(Text.Rad2ChooseLanguage),
            };
        }
        public static void MenuMain(Garage<IVehicle> garage) {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("sv-SE");

            while (Running) {
                LoadMenuText();
                string? input = Utilities.ShowMenu(Utilities.Cap(Text.MainHeader), menuTextMain, Text.exit);
                switch (input) {
                    case "1":
                        MenuAddVehicle(garage);
                        break;
                    case "2":
                        MenuRemoveVehicle(garage);
                        break;
                    case "3":
                        MenuShowVehicle(garage);
                        break;
                    case "4":
                        garage = MenuLoadVehicleFromFile(garage);
                        break;
                    case "5":
                        MenuChooseLanguage();
                        break;
                    case "0":
                        UI.ExitGarage();
                        break;
                    default:
                        Console.WriteLine($"{Utilities.Tab}Ogiltigt val");
                        Console.ReadKey();
                        break;
                }
            }
        }
        internal static void MenuAddVehicle(Garage<IVehicle> garage) {
            bool running = true;
            while (running) {
                LoadMenuText();

                string? input = Utilities.ShowMenu(Text.Rad1Main, menuTextAdd, Text.Back);
                switch (input) {
                    case "1":
                        Handler.AddVehicle(garage, Utilities.VType.Car);
                        break;
                    case "2":
                        Handler.AddVehicle(garage, Utilities.VType.Bus);
                        break;
                    case "3":
                        Handler.AddVehicle(garage, Utilities.VType.Motorcycle);
                        break;
                    case "4":
                        Handler.AddVehicle(garage, Utilities.VType.Boat);
                        break;
                    case "5":
                        Handler.AddVehicle(garage, Utilities.VType.Airplane);
                        break;
                    case "6":
                        Handler.AddRandomVehicles(garage);
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Handler.OgitigtVal();
                        break;
                }
            }
        }
        internal static void MenuRemoveVehicle(Garage<IVehicle> garage) {
            bool running = true;
            while (running) {
                string? input = Utilities.ShowMenu(Text.Rad2Main, menuTextRemove, Text.Back);
                switch (input) {
                    case "1":
                        Handler.RemoveVehicle(garage);
                        break;
                    case "2":
                        Handler.RemoveVehicleRegNum(garage);
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Handler.OgitigtVal();
                        break;
                }
            }
        }
        internal static void MenuShowVehicle(Garage<IVehicle> garage) {
            bool running = true;
            while (running) {
                string input = Utilities.ShowMenu(Text.Rad3Main, menuTextShow, Text.Back).Trim();
                switch (input) {
                    case "1":
                        Handler.ListVehicles(garage);
                        Console.WriteLine($"{Utilities.Tab}{Text.TryckRetur}");
                        Console.ReadLine();
                        break;
                    case "2":
                        Handler.FindVehicleByRegNumber(garage);
                        break;
                    case "3":
                        Handler.SeachAndFilterVehicles(garage);
                        Console.WriteLine($"{Utilities.Tab}{Text.TryckRetur}");
                        Console.ReadLine();
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Handler.OgitigtVal();
                        break;
                }
            }
        }
        internal static Garage<IVehicle> MenuLoadVehicleFromFile(Garage<IVehicle> garage) {
            bool running = true;
            while (running) {
                string? input = Utilities.ShowMenu(Text.Rad4Main, menuLoadFromFile, Text.Back);
                switch (input) {
                    case "1":
                        var result = Utilities.NavigateToOpen(garage);
                        garage = result.Item2;
                        Console.WriteLine($"{Utilities.Tab}{result.Item1}");
                        Console.ReadKey();
                        break;
                    case "2":
                        Utilities.NavigateToSave(garage);
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Handler.OgitigtVal();
                        break;
                }
            }
            return garage;
        }
        internal static void MenuChooseLanguage() {
            bool running = true;
            while (running) {
                string? input = Utilities.ShowMenu(Text.Rad5Main, menuTextLanguage, Text.Back);
                switch (input) {
                    case "1":
                        Console.WriteLine($"{Utilities.Tab}Valt språk: Svenska");
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("sv-SE");
                        running = false;
                        break;
                    case "2":
                        Console.WriteLine($"{Utilities.Tab}Valt språk: Engelska");
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                        running = false;
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Handler.OgitigtVal();
                        break;
                }
            }
        }
        internal static void ExitGarage() {
            // Här kan allt sparas eller städas upp innan programmet avslutas
            string closing = "Programmet avslutas...";
            Console.Write(Utilities.Tab);
            foreach (var item in closing) {
                Console.Write(item);
                Thread.Sleep(50);
            }
#if UNIT_TEST
            Utilities.SaveVehicles(garage, filePath);
#endif
            Running = false;
        }
    }
}
