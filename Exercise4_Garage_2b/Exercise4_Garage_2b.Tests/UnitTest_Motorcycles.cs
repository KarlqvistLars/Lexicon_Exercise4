using Exercise4_Garage_2b.VehicleClasses;

namespace Exercise4_Garage_2b.Tests {
    public class UnitTest_Motorcycle {
        [Fact]
        public void TestMotorcycleClass() {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;

            Vehicle motorcycle = new Motorcycle("MCT 123", "Grön", 185, 1.85m, 900, 2);

            using var input = new StringReader("");
            using var output = new StringWriter();

            try {
                Console.SetIn(input);
                Console.SetOut(output);

                // Act
                Console.SetIn(input);
                var id = motorcycle.Uuid;
                var color = motorcycle.Color;
                var weight = motorcycle.Weight;
                var length = motorcycle.Length;
                var cubicInch = ((Motorcycle)motorcycle).CubicInch;
                var wheels = ((Motorcycle)motorcycle).Wheels;
                bool result = id == "MCT 123" && color == "Grön" && weight == 185 && length == 1.85m && cubicInch == 900 && wheels == 2;
                string consolUtrskrift = motorcycle.ToString2(Utilities.VType.Motorcycle);

                // Assert
                Assert.True(result);
                Assert.Contains("MCT 123", consolUtrskrift);
                Assert.Contains("Grön", consolUtrskrift);
                Assert.Contains("185", consolUtrskrift);
                Assert.Contains("1,85", consolUtrskrift);
                Assert.Contains("900", consolUtrskrift);
                Assert.Contains("2", consolUtrskrift);

            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
                input.Close();
                output.Close();
            }
        }
    }
}
