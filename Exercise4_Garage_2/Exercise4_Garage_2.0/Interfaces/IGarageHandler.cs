namespace Exercise4_Garage_2.Interfaces
{
    interface IGarageHandler
    {
        public void CreateGarage();
        public void RunGarage();
        public bool AddVehicle(Vehicle vehicle);
        public bool RemoveVehicle(string uuid);
        //public Vehicle[] GetVehicles();
        public string VehicleToString();
    }
}
