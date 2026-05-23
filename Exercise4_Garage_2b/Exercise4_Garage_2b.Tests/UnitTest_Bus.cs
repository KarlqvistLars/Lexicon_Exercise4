namespace Exercise4_Garage_2b.Tests {
    public class UnitTest_Bus {
        [Fact]
        public void TestBusClass() {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;

            Vehicle bus = new Bus("BUS 123", "Blå", 15000, 12.2m, 2, 4);

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
                bool result = id == "BUS 123" && color == "Blå" && weight == 15000 && length == 12.2m && numberOfSeats == 2 && wheels == 4;
                string consolUtrskrift = bus.ToString2(Utilities.VType.Bus);

                if (false) {
                    StreamWriter fileWriter = new StreamWriter("test_output.txt");
                    fileWriter.WriteLine(consolUtrskrift);
                    fileWriter.Close();
                }

                // Assert
                Assert.True(result);
                Assert.Contains("BUS 123", consolUtrskrift);
                Assert.Contains("Blå", consolUtrskrift);
                Assert.Contains("15000", consolUtrskrift);
                Assert.Contains("12,2", consolUtrskrift);
                Assert.Contains("2", consolUtrskrift);
                Assert.Contains("4", consolUtrskrift);

            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
                input.Close();
                output.Close();
            }
        }
    }
}
