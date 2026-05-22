namespace Exercise4_Garage_2b.Interfaces {
    public interface IHandler {
        bool StartGarage(int garageSize, bool populate);
        void AddVehicle(Garage<IVehicle> garage, Utilities.VType type);
        void AddRandomVehicles(Garage<IVehicle> garage, int count = 0);
        bool RemoveVehicle(Garage<IVehicle> garage);
        void RemoveVehicleRegNum(Garage<IVehicle> garage);
    }
}
