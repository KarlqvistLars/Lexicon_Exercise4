using static Exercise4_Garage_2b.Utilities;

namespace Exercise4_Garage_2b.Tests {
    public partial class UnitTest_Handler {
        [Fact]
        public void TestShowGarageSearchWithVehicles() {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;
            Handler handler = new Handler();
            using var output = new StringWriter();
            Garage<IVehicle> garage = new Garage<IVehicle>(10);
            Vehicle car1 = new Car("ABC 123", "Red", 1500, 5.2m, 2, 4);
            Vehicle car2 = new Car("DEF 456", "Blue", 1600, 4.5m, 2, 4);
            garage.Add(car1);
            garage.Add(car2);
            try {
                Console.SetOut(output);
                //Act
                var result = handler.ShowGarageSearch(garage, VType.Car, string.Empty, string.Empty, 0, 0);
                //Assert
                string consolUtrskrift = output.ToString();
                Assert.True(result.Item1);
                Assert.True(consolUtrskrift.Contains("ABC 123"));
                Assert.True(consolUtrskrift.Contains("DEF 456"));
            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
                //input.Close();
                output.Close();
            }
        }
    }
}