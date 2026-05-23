namespace Exercise4_Garage_2b.Tests {
    public class UnitTest_Bus {
        [Theory]
        [InlineData("BUS 123", "Blå", 15000, 12.2, 2, 4)]
        public void TestBusClass(string in_uuid, string in_color, int in_weight, double in_length, int in_numberOfSeats, int in_wheels) {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;

            Vehicle bus = new Bus(in_uuid, in_color, in_weight, (decimal)in_length, in_numberOfSeats, in_wheels);

            using var input = new StringReader("");
            using var output = new StringWriter();

            try {
                Console.SetIn(input);
                Console.SetOut(output);

                // Act
                Console.SetIn(input);
                var id = bus.Uuid;
                var color = bus.Color;
                var weight = bus.Weight;
                var length = bus.Length;
                var numberOfSeats = ((Bus)bus).NumberOfSeats;
                var wheels = ((Bus)bus).Wheels;
                bool result = id == in_uuid && color == in_color && weight == in_weight && length == (decimal)in_length && numberOfSeats == in_numberOfSeats && wheels == in_wheels;
                string consolUtrskrift = bus.ToString2(Utilities.VType.Bus);

                if (false) {
                    StreamWriter fileWriter = new StreamWriter("test_output.txt");
                    fileWriter.WriteLine(consolUtrskrift);
                    fileWriter.Close();
                }

                // Assert
                Assert.True(result);
                Assert.Contains(in_uuid, consolUtrskrift);
                Assert.Contains(in_color, consolUtrskrift);
                Assert.Contains(in_weight.ToString(), consolUtrskrift);
                Assert.Contains(((decimal)in_length).ToString(), consolUtrskrift);
                Assert.Contains(in_numberOfSeats.ToString(), consolUtrskrift);
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
