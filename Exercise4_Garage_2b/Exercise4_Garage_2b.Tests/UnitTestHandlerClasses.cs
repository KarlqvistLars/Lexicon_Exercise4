using System.Globalization;
using static Exercise4_Garage_2b.Utilities;


namespace Exercise4_Garage_2b.Tests {
    public class UnitTestHandlerClasses {
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
            }
        }

        [Fact]
        public void TestShowGarageSearch() {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;

            Handler handler = new Handler();

            using var output = new StringWriter();

            Garage<IVehicle> garage = new Garage<IVehicle>(10);

            try {
                Console.SetOut(output);

                //Act
                var result = handler.ShowGarageSearch(garage, VType.None, string.Empty, string.Empty, 0, 0);

                //Assert
                string consolUtrskrift = output.ToString();

                Assert.False(result.Item1);
                Assert.True(consolUtrskrift.Contains("Garaget är tomt"));

            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
            }
        }

    }
}