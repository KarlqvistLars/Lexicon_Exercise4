namespace Exercise4_Garage_2.Interfaces
{
    public interface IHandler
    {

        bool StartGarage(int garageSize, bool populate);

        void AddCar(Garage<IVehicle> garage);
        void AddBus(Garage<IVehicle> garage);
        void AddMotorcycle(Garage<IVehicle> garage);
        void AddBoat(Garage<IVehicle> garage);
        void AddAirplane(Garage<IVehicle> garage);
        void AddRandomVehicles(Garage<IVehicle> garage, int count = 0);
        void AddVehicle(Garage<IVehicle> garage);
        void RemoveVehicle(Garage<IVehicle> garage);

    }
}
