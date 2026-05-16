namespace Exercise4_Garage_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Garage<IVehicle> garage = new Garage<IVehicle>(10); // Example size
            UI.MenuMain(garage);
        }
    }
}