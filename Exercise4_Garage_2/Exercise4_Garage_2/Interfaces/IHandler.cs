namespace Exercise4_Garage_2.Interfaces
{
    internal interface IHandler
    {
        void AddCar();
        void AddBus();
        void AddMotorcycle();
        void AddBoat();
        void AddAirplane();
        void AddRandomVehicles(int count = 0);
        void AddVehicle();
        void RemoveVehicle();

    }
}
