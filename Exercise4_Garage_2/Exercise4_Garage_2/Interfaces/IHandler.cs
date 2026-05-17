namespace Exercise4_Garage_2.Interfaces
{
    public interface IHandler
    {
        bool StartGarage(int garageSize, bool populate);
        void AddVehicle(Garage<IVehicle> garage, Utilities.VType type);
        void AddRandomVehicles(Garage<IVehicle> garage, int count = 0);
        void RemoveVehicle(Garage<IVehicle> garage);
        void RemoveVehicleRegNum(Garage<IVehicle> garage);

    }
}
