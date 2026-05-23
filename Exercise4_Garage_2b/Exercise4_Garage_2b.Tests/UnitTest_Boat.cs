using Exercise4_Garage_2b.VehicleClasses;

namespace Exercise4_Garage_2b.Tests {
    public class UnitTest_Boat {
        [Fact]
        public void TestBoatClass() {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;

            Vehicle boat = new Boat("BC12345", "Vit", 12000, 15.2m, 2, 14.3m, 20000);

            using var input = new StringReader("");
            using var output = new StringWriter();

            try {
                Console.SetIn(input);
                Console.SetOut(output);

                // Act
                Console.SetIn(input);
                var id = boat.Uuid;
                var color = boat.Color;
                var weight = boat.Weight;
                var length = boat.Length;
                var maxWaterDepth = ((Boat)boat).MaxWaterDepth;
                var maxSpeed = ((Boat)boat).MaxSpeed;
                var deplacement = ((Boat)boat).Deplacement;
                bool result = id == "BC12345" && color == "Vit" && weight == 12000 && length == 15.2m && maxWaterDepth == 2 && maxSpeed == 14.3m && deplacement == 20000;
                string consolUtrskrift = boat.ToString2(Utilities.VType.Boat);


                // Assert
                Assert.True(result);
                Assert.Contains("BC12345", consolUtrskrift);
                Assert.Contains("Vit", consolUtrskrift);
                Assert.Contains("12000", consolUtrskrift);
                Assert.Contains("15,2", consolUtrskrift);
                Assert.Contains("2", consolUtrskrift);
                Assert.Contains("14,3", consolUtrskrift);
                Assert.Contains("20000", consolUtrskrift);

            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
                input.Close();
                output.Close();
            }
        }
    }
}
