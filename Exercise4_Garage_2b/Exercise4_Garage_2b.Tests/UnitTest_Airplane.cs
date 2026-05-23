using Exercise4_Garage_2b.VehicleClasses;

namespace Exercise4_Garage_2b.Tests {
    public class UnitTest_Airplane {
        [Fact]
        public void TestAirplaneClass() {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;

            Vehicle airplane = new Airplane("SE-UPP", "Vit", 280, 6.6m, 450, 15, 1);

            using var input = new StringReader("");
            using var output = new StringWriter();

            try {
                Console.SetIn(input);
                Console.SetOut(output);

                // Act
                Console.SetIn(input);
                var id = airplane.Uuid;
                var color = airplane.Color;
                var weight = airplane.Weight;
                var length = airplane.Length;
                var lift = ((Airplane)airplane).LiftCapacity;
                var wingspan = ((Airplane)airplane).WingSpan;
                var passengers = ((Airplane)airplane).Passengers;
                bool result = id == "SE-UPP" && color == "Vit" && weight == 280 && length == 6.6m && lift == 450 && wingspan == 15 && passengers == 1;
                string consolUtrskrift = airplane.ToString2(Utilities.VType.Airplane);

                // Assert
                Assert.True(result);
                Assert.Contains("SE-UPP", consolUtrskrift);
                Assert.Contains("Vit", consolUtrskrift);
                Assert.Contains("280", consolUtrskrift);
                Assert.Contains("6,6", consolUtrskrift);
                Assert.Contains("450", consolUtrskrift);
                Assert.Contains("15", consolUtrskrift);
                Assert.Contains("1", consolUtrskrift);

            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
                input.Close();
                output.Close();
            }
        }
    }
}
