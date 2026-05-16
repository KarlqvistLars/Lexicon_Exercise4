namespace Exercise4_Garage_2.Interfaces
{
    public interface IHandler
    {
        bool StartGarage(int garageSize, bool populate);
        void AddVehicle(Garage<IVehicle> garage, Utilities.VType type);
        void AddCar(Garage<IVehicle> garage);
        void AddBus(Garage<IVehicle> garage);
        void AddMotorcycle(Garage<IVehicle> garage);
        void AddBoat(Garage<IVehicle> garage);
        void AddAirplane(Garage<IVehicle> garage);
        void AddRandomVehicles(Garage<IVehicle> garage, int count = 0);
        void RemoveVehicle(Garage<IVehicle> garage);
        void RemoveVehicleRegNum(Garage<IVehicle> garage);

    }
}
