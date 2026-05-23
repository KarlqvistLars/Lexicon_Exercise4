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

            using var input08 = new StringReader("k");
            using var output08 = new StringWriter();

            try {
                Console.SetIn(input08);
                Console.SetOut(output08);

                // Act
                var result08 = handler.OgitigtVal();

                // Assert
                string consolUtrsk08 = output08.ToString();
                Assert.True(result08);
                Assert.Contains("Ogiltigt val", consolUtrsk08);
                Assert.Contains("Tryck Retur", consolUtrsk08);

            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
            }
        }
    }
}