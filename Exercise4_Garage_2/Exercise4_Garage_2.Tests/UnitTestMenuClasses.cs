using Exercise4_Garage_2.MenuClasses;

namespace Exercise4_Garage_2.Tests
{
    public class UnitTestMenuClasses
    {
        [Fact]
        public void TestMenuAddVehicle()
        {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;

            using var input = new StringReader("0\n\n");
            using var output = new StringWriter();
            Console.SetIn(input);
            Console.SetOut(output);

            try
            {
                // Act
                UI.MenuAddVehicle();

                // Hämtar allt som skrivits till console
                string result = output.ToString();

                // Assert
                Assert.Contains($"Lägg till fordon\r\n", result);
                Assert.Contains("Bil\r\n", result);
                Assert.Contains("Buss\r\n", result);
                Assert.Contains("Motorcykel\r\n", result);
                Assert.Contains("Båt\r\n", result);
                Assert.Contains("Flygplan\r\n", result);
                Assert.Contains("Slunpmässigt\r\n", result);
            }
            finally
            {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
            }

        }
    }
}
