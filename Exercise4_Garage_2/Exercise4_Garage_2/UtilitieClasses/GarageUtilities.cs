namespace Exercise4_Garage_2
{
    public class GarageUtilities
    {
        readonly static string Line30 = new string('=', 30);
        readonly static string Tab = new string(' ', 3);
        /// <summary>
        /// Alla menyer under "Lägg till fordon".
        /// </summary>
        internal static void AddCar(Garage G)
        {
            string[] v = new string[4];
            string Title = "Lägg till Bil...";
            Utilities.ShowHeader(Title);
            v = Vehicle.InDataVehicle();
            //Vehicle vehicle = new Car(regNum.ToUpper(), color ?? string.Empty, weight, length, 4, doors);
            Console.WriteLine($"{Tab}Denna bil har lagts till i garaget.\n{Tab}Tryck Retur för att fortsätta...");
            Console.ReadLine();
        }
























        internal static void AddBus(Garage G)
        {
            string Title = "Lägg till Buss";
            //ShowHeader(Title);

        }
        internal static void AddMotorcycle(Garage G)
        {
            string Title = $" Lägg till MC";
            //ShowHeader(Title);

        }
        internal static void AddBoat(Garage G)
        {
            string Title = $"Lägg till Båt";
            //ShowHeader(Title);

            //Console.WriteLine($"{Utilities.Tab}Denna båt har lagts till i garaget.\n{Utilities.Tab}Tryck Retur för att fortsätta...");
            Console.ReadLine();
        }
        internal static void AddAirplane(Garage G)
        {
            string Title = $"Lägg till FLP";
            //ShowHeader(Title);

            Console.WriteLine($"{Utilities.Tab}Detta flygplan har lagts till i garaget.\n{Utilities.Tab}Tryck Retur för att fortsätta...");
            Console.ReadLine();
        }
        internal static void AddRandomVehicles(Garage G, int count = 0)
        {
            string Title = "Lägg till slumpade fordon";

            Console.WriteLine($"{Utilities.Tab}Tryck på valfri tangent för att återgå till huvudmenyn...");
            Console.ReadLine();
        }


    }
}
