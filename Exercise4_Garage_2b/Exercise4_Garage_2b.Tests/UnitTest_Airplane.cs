using Exercise4_Garage_2b.VehicleClasses;

namespace Exercise4_Garage_2b.Tests {
    public class UnitTest_Airplane {
        [Theory]
        [InlineData("SE-UPP", "Vit", 280, 6.6, 450, 15, 1)]
        //[InlineData("Fl45003", "Vit", 14000, 15.2, 2, 14.3, 22000)]
        public void TestAirplaneClass(string in_uuid, string in_color, int in_weight, double in_length, int in_lift, int in_wingspan, int in_passengers) {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;

            Vehicle airplane = new Airplane(in_uuid, in_color, in_weight, (decimal)in_length, in_lift, in_wingspan, in_passengers);

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
                bool result = id == in_uuid && color == in_color && weight == in_weight && length == (decimal)in_length && lift == in_lift && wingspan == in_wingspan && passengers == in_passengers;
                string consolUtrskrift = airplane.ToString2(Utilities.VType.Airplane);

                // Assert
                Assert.True(result);
                Assert.Contains(in_uuid, consolUtrskrift);
                Assert.Contains(in_color, consolUtrskrift);
                Assert.Contains(in_weight.ToString(), consolUtrskrift);
                Assert.Contains(((decimal)in_length).ToString(), consolUtrskrift);
                Assert.Contains(in_lift.ToString(), consolUtrskrift);
                Assert.Contains(in_wingspan.ToString(), consolUtrskrift);
                Assert.Contains(in_passengers.ToString(), consolUtrskrift);

            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
                input.Close();
                output.Close();
            }
        }
    }
}
