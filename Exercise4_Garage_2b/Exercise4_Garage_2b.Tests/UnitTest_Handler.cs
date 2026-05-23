using Exercise4_Garage_2b.VehicleClasses;

namespace Exercise4_Garage_2b.Tests {
    public partial class UnitTest_Handler {

        public static Garage<IVehicle> CreateGarageWithVehicles() {
            Garage<IVehicle> garage = new Garage<IVehicle>(10);
            garage.Add(new Car("ABC 123", "Röd", 1500, 5.2m, 2, 4));
            garage.Add(new Car("DEF 456", "Blå", 1600, 4.5m, 2, 4));
            garage.Add(new Bus("ABC 123", "Röd", 1500, 5.2m, 2, 4));
            garage.Add(new Bus("DEF 456", "Blå", 1600, 4.5m, 2, 4));
            garage.Add(new Boat("AB12345", "Röd", 15000, 14.2m, 2m, 14.6m, 25000m));
            garage.Add(new Boat("DE67890", "Blå", 16000, 17.5m, 2m, 12.2m, 26000m));
            return garage;
        }
    }
}

