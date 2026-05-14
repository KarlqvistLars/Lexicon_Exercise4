using Exercise4_Garage_2.Interfaces;
using Exercise4_Garage_2.MenuClasses;

namespace Exercise4_Garage_2
{
    public class MenuHandler : IMenuHandler
    {
        private static bool Running { get; set; } = true;
        public static bool StartGarage(int garageSize, bool populate = false)
        {
            if (populate == false)
            {
                //garage = new Garage(garageSize);
                MenuMain();
            }
            else
            {
                //garage = new Garage(20); // Standardstorlek
                //GarageHandler.AddStartVehicles(15); // Lägg till 15 slumpmässiga fordon
                MenuMain();
            }
            return true;
        }
        public static void MenuMain()
        {
            string[] options = new string[]
            {
                Text.Rad1Main,
                Text.Rad2Main,
                Text.Rad3Main,
                Text.Rad4Main,
                Text.Rad5Main
            };

            while (Running)
            {
                string? input = Utilities.ShowMenu(Text.MainHeader, options, "Avsluta");
                switch (input)
                {
                    case "1":
                        MenuAddVehicle();
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
                        MenuHandler.ExitGarage();
                        break;

                    default:
                        Console.WriteLine($"{Utilities.Tab}Ogiltigt val");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private static void MenuAddVehicle()
        {
            bool running = true;
            string[] options = new string[]
            {
                Text.Rad1AddVehicle,
                Text.Rad2AddVehicle,
                Text.Rad3AddVehicle,
                Text.Rad4AddVehicle,
                Text.Rad5AddVehicle,
                Text.Rad6AddVehicle
            };
            while (running)
            {
                string? input = Utilities.ShowMenu(Text.Rad1Main, options);
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
            string[] options = new string[]
            {
                Text.Rad1RemoveVehicle,
                Text.Rad2RemoveVehicle,
            };

            while (running)
            {
                string? input = Utilities.ShowMenu(Text.Rad2Main, options);
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
            string[] options = new string[]
            {
                Text.Rad1ShowVehicle,
                Text.Rad2ShowVehicle,
                Text.Rad3ShowVehicle
            };

            while (running)
            {
                string? input = Utilities.ShowMenu(Text.Rad3Main, options);
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
            string[] options = new string[]
            {
                Text.Rad1LoadVehicleFromFilePart1+"\n"+Utilities.Tab+Text.Rad1LoadVehicleFromFilePart2,
            };

            while (running)
            {
                string? input = Utilities.ShowMenu(Text.Rad4Main, options);
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
            string[] options = new string[]
            {
                Text.Rad1ChooseLanguage,
                Text.Rad2ChooseLanguage,
            };

            while (running)
            {
                string? input = Utilities.ShowMenu(Text.Rad5Main, options);
                switch (input)
                {
                    case "1":
                        Console.WriteLine($"{Utilities.Tab}Valt språk: Svenska");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine($"{Utilities.Tab}Valt språk: Engelska");
                        Console.ReadKey();
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
