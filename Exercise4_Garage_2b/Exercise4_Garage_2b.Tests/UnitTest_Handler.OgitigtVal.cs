using System.Globalization;

namespace Exercise4_Garage_2b.Tests {
    public partial class UnitTest_Handler {
        [Fact]
        public void TestOgitigtVal() {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("sv-SE");
            Handler handler = new Handler();

            using var input = new StringReader("k");
            using var output = new StringWriter();

            try {
                Console.SetIn(input);
                Console.SetOut(output);

                // Act
                Console.SetIn(input);
                var result = handler.OgitigtVal();

                // Assert
                string consolUtrskrift = output.ToString();
                Assert.True(result);
                Assert.True(consolUtrskrift.Contains("Ogiltigt val"));
                Assert.Contains("Tryck Retur", consolUtrskrift);

            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
                input.Close();
                output.Close();
            }
        }
    }
}