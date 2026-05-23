using Exercise4_Garage_2b.VehicleClasses;

namespace Exercise4_Garage_2b.Tests {
    public class UnitTest_Motorcycle {
        [Theory]
        [InlineData("MCT 123", "Grön", 185, 1.85, 900, 2)]
        [InlineData("DEF 456", "Blå", 1600, 4.8, 4, 4)]
        public void TestMotorcycleClass(string in_uuid, string in_color, int in_weight, double in_length, int in_cubicInch, int in_wheels) {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;

            Vehicle motorcycle = new Motorcycle(in_uuid, in_color, in_weight, (decimal)in_length, in_cubicInch, in_wheels);

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
                bool result = id == in_uuid && color == in_color && weight == in_weight && length == (decimal)in_length && cubicInch == in_cubicInch && wheels == in_wheels;
                string consolUtrskrift = motorcycle.ToString2(Utilities.VType.Motorcycle);

                // Assert
                Assert.True(result);
                Assert.Contains(in_uuid, consolUtrskrift);
                Assert.Contains(in_color, consolUtrskrift);
                Assert.Contains(in_weight.ToString(), consolUtrskrift);
                Assert.Contains(((decimal)in_length).ToString(), consolUtrskrift);
                Assert.Contains(in_cubicInch.ToString(), consolUtrskrift);
                Assert.Contains(in_wheels.ToString(), consolUtrskrift);

            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
                input.Close();
                output.Close();
            }
        }
    }
}
