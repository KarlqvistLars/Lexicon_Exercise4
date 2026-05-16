using Exercise4_Garage_2.Interfaces;
using Exercise4_Garage_2.MenuClasses;
using System.Globalization;

namespace Exercise4_Garage_2
{
    public class UI : IUI
    {
        private static bool Running { get; set; } = true;
        static string[] menuTextMain = new string[] { };
        static string[] menuTextAdd = new string[] { };
        static string[] menuTextRemove = new string[] { };
        static string[] menuTextShow = new string[] { };
        static string[] menuLoadFromFile = new string[] { };
        static string[] menuTextLanguage = new string[] { };
        private static Handler Handler = new Handler();
        public static void LoadMenuText()
        {
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
                Utilities.Cap(Text.Rad1LoadVehicleFromFilePart1)+"\n"+Utilities.Tab+Utilities.Cap(Text.Rad1LoadVehicleFromFilePart2),
            };
            menuTextLanguage = new string[]
            {
                Utilities.Cap(Text.Rad1ChooseLanguage),
                Utilities.Cap(Text.Rad2ChooseLanguage),
            };
        }
        public static void MenuMain(Garage<IVehicle> garage)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            while (Running)
            {
                LoadMenuText();
                string? input = Utilities.ShowMenu(Utilities.Cap(Text.MainHeader), menuTextMain, Text.exit);
                switch (input)
                {
                    case "1":
                        MenuAddVehicle(garage);
                        break;

                    case "2":
                        MenuRemoveVehicle();
                        break;

                    case "3":
                        MenuShowVehicle();
                        break;

                    case "4":
                        MenuLoadVehicleFromFile();
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
        private static void MenuAddVehicle(Garage<IVehicle> garage)
        {
            bool running = true;
            while (running)
            {
                LoadMenuText();

                string? input = Utilities.ShowMenu(Text.Rad1Main, menuTextAdd, Text.Back);
                switch (input)
                {
                    case "1":
                        Handler.AddCar(garage);
                        break;
                    case "2":
                        //MenuRemoveVehicle();
                        break;
                    case "3":
                        //MenuShowVehicle();
                        break;
                    case "4":
                        //MenuLoadVehicleFromFile();
                        break;
                    case "5":
                        //MenuLoadVehicleFromFile();
                        break;
                    case "6":
                        //MenuLoadVehicleFromFile();
                        break;
                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine($"{Utilities.Tab}Ogiltigt val");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private static void MenuRemoveVehicle()
        {
            bool running = true;
            while (running)
            {
                string? input = Utilities.ShowMenu(Text.Rad2Main, menuTextRemove, Text.Back);
                switch (input)
                {
                    case "1":
                        //MenuAddVehicle();
                        break;

                    case "2":
                        //MenuRemoveVehicle();
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine($"{Utilities.Tab}Ogiltigt val");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private static void MenuShowVehicle()
        {
            bool running = true;
            while (running)
            {
                string? input = Utilities.ShowMenu(Text.Rad3Main, menuTextShow, Text.Back);
                switch (input)
                {
                    case "1":
                        //MenuAddVehicle();
                        break;
                    case "2":
                        //MenuRemoveVehicle();
                        break;
                    case "3":
                        //MenuShowVehicle();
                        break;
                    case "4":
                        //MenuLoadVehicleFromFile();
                        break;
                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine($"{Utilities.Tab}Ogiltigt val");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private static void MenuLoadVehicleFromFile()
        {
            bool running = true;
            while (running)
            {
                string? input = Utilities.ShowMenu(Text.Rad4Main, menuLoadFromFile, Text.Back);
                switch (input)
                {
                    case "1":
                        //MenuAddVehicle();
                        break;

                    case "2":
                        //MenuRemoveVehicle();
                        break;

                    case "3":
                        //MenuShowVehicle();
                        break;

                    case "4":
                        //MenuLoadVehicleFromFile();
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine($"{Utilities.Tab}Ogiltigt val");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private static void MenuChooseLanguage()
        {
            bool running = true;
            while (running)
            {
                string? input = Utilities.ShowMenu(Text.Rad5Main, menuTextLanguage, Text.Back);
                switch (input)
                {
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
                        Console.WriteLine($"{Utilities.Tab}Ogiltigt val");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private static void ExitGarage()
        {
            // Här kan allt sparas eller städas upp innan programmet avslutas
            string closing = "Programmet avslutas...";
            Console.Write(Utilities.Tab);
            foreach (var item in closing)
            {
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
