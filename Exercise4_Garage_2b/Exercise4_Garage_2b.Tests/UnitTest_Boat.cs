using Exercise4_Garage_2b.VehicleClasses;

namespace Exercise4_Garage_2b.Tests {
    public class UnitTest_Boat {
        [Theory]
        [InlineData("AB12345", "Vit", 12000, 15.2, 2, 14.3, 20000)]
        [InlineData("Fl45003", "Vit", 14000, 15.2, 2, 14.3, 22000)]
        [InlineData("CD67890", "Vit", 13500, 15.2, 2, 14.3, 18000)]
        [InlineData("EF11223", "Vit", 1200, 15.2, 2, 14.3, 2000)]
        [InlineData("GH44556", "Vit", 12000, 15.2, 2, 14.3, 20000)]
        public void TestBoatClass(string in_uuid, string in_color, int in_weight, double in_length, int in_maxWaterDepth, double in_maxSpeed, int in_deplacement) {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;

            Vehicle boat = new Boat(in_uuid, in_color, in_weight, (decimal)in_length, in_maxWaterDepth, (decimal)in_maxSpeed, in_deplacement);

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
                bool result = id == in_uuid && color == in_color && weight == in_weight && length == (decimal)in_length && maxWaterDepth == in_maxWaterDepth && maxSpeed == (decimal)in_maxSpeed && deplacement == in_deplacement;
                string consolUtrskrift = boat.ToString2(Utilities.VType.Boat);


                // Assert
                Assert.True(result);
                Assert.Contains(in_uuid, consolUtrskrift);
                Assert.Contains(in_color, consolUtrskrift);
                Assert.Contains(in_weight.ToString(), consolUtrskrift);
                Assert.Contains(((decimal)in_length).ToString(), consolUtrskrift);
                Assert.Contains(in_maxWaterDepth.ToString(), consolUtrskrift);
                Assert.Contains(((decimal)in_maxSpeed).ToString(), consolUtrskrift);
                Assert.Contains(in_deplacement.ToString(), consolUtrskrift);

            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
                input.Close();
                output.Close();
            }
        }
    }
}
