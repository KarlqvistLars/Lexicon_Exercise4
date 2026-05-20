using Exercise4_Garage_2.MenuClasses;

namespace Exercise4_Garage_2.Tests {
    public class UnitTestMenuClasses {
        [Fact]
        public void TestMenuAddVehicle() {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;

            using var input = new StringReader("0\n\n");
            using var output = new StringWriter();
            Console.SetIn(input);
            Console.SetOut(output);

            try {
                // Act
                UI.MenuAddVehicle();

                // Hämtar allt som skrivits till console
                string result = output.ToString();

                // Assert
                Assert.Contains($"{Text.LaggTill} {Text.Fordon}\r\n", result);
                Assert.Contains($"{Text.Bil}\r\n", result);
                Assert.Contains($"{Text.Buss}\r\n", result);
                Assert.Contains($"{Text.Motorcykel}\r\n", result);
                Assert.Contains($"{Text.Boat}\r\n", result);
                Assert.Contains($"{Text.Flygplan}\r\n", result);
                Assert.Contains($"{Text.SlumpadeFordon}\r\n", result);
            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
            }

        }
    }
}
