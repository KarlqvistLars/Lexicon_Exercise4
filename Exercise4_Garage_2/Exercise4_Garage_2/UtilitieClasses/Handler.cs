using Exercise4_Garage_2.Interfaces;

namespace Exercise4_Garage_2
{
    public class Handler : IHandler
    {
        readonly static string Line30 = new string('=', 30);
        readonly static string Tab = new string(' ', 3);
        /// <summary>
        /// Alla menyer under "Lägg till fordon".
        /// </summary>
        public void AddCar()
        {
            string[] v = new string[4];
            string Title = "Lägg till Bil...";
            Utilities.ShowHeader(Title);
            v = Vehicle.InDataVehicle();
            //Vehicle vehicle = new Car(regNum.ToUpper(), color ?? string.Empty, weight, length, 4, doors);
            Console.WriteLine($"{Tab}Denna bil har lagts till i garaget.\n{Tab}Tryck Retur för att fortsätta...");
            Console.ReadLine();
        }
























        public void AddBus()
        {
            string Title = "Lägg till Buss";
            //ShowHeader(Title);

        }
        public void AddMotorcycle()
        {
            string Title = $" Lägg till MC";
            //ShowHeader(Title);

        }
        public void AddBoat()
        {
            string Title = $"Lägg till Båt";
            //ShowHeader(Title);

            //Console.WriteLine($"{Utilities.Tab}Denna båt har lagts till i garaget.\n{Utilities.Tab}Tryck Retur för att fortsätta...");
            Console.ReadLine();
        }
        public void AddAirplane()
        {
            string Title = $"Lägg till FLP";
            //ShowHeader(Title);

            Console.WriteLine($"{Utilities.Tab}Detta flygplan har lagts till i garaget.\n{Utilities.Tab}Tryck Retur för att fortsätta...");
            Console.ReadLine();
        }
        public void AddRandomVehicles(int count = 0)
        {
            string Title = "Lägg till slumpade fordon";

            Console.WriteLine($"{Utilities.Tab}Tryck på valfri tangent för att återgå till huvudmenyn...");
            Console.ReadLine();
        }


        public void AddVehicle()
        {
            string Title = "Lägg till fordon";
            //ShowHeader(Title);
            Console.WriteLine($"{Utilities.Tab}Tryck på valfri tangent för att återgå till huvudmenyn...");
            Console.ReadLine();
        }

        public void RemoveVehicle()
        {
            string Title = "Ta bort fordon";
            //ShowHeader(Title);
            Console.WriteLine($"{Utilities.Tab}Tryck på valfri tangent för att återgå till huvudmenyn...");
            Console.ReadLine();

        }
    }
}
