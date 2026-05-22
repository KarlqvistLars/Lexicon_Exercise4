using Exercise4_Garage_2b.VehicleClasses;
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

        [Fact]
        public void TestShowGarageSearchWithVehicles() {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;
            Handler handler = new Handler();
            using var output = new StringWriter();
            Garage<IVehicle> garage = new Garage<IVehicle>(10);
            Vehicle car1 = new Car("ABC 123", "Red", 1500, 5.2m, 2, 4);
            Vehicle car2 = new Car("DEF 456", "Blue", 1600, 4.5m, 2, 4);
            garage.Add(car1);
            garage.Add(car2);
            try {
                Console.SetOut(output);
                //Act
                var result = handler.ShowGarageSearch(garage, VType.Car, string.Empty, string.Empty, 0, 0);
                //Assert
                string consolUtrskrift = output.ToString();
                Assert.True(result.Item1);
                Assert.True(consolUtrskrift.Contains("ABC 123"));
                Assert.True(consolUtrskrift.Contains("DEF 456"));
            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
            }

        }

        [InlineData("ABC 123")]
        [Theory]
        public void TestRemoveVehicleRegNum(string regNum) {
            //Arrange
            var input = new StringReader(regNum);
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;
            Handler handler = new Handler();
            using var output = new StringWriter();
            Garage<IVehicle> garage = CreateGarageWithVehicles();

            try {
                Console.SetIn(input);
                Console.SetOut(output);
                //Act
                var countBefore = garage.Count;
                handler.RemoveVehicleRegNum(garage);
                var countAfter = garage.Count;
                string consolUtrskrift = output.ToString();

                //Assert
                Assert.Equal(countBefore, 6);
                Assert.Equal(countAfter, 5);

            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
            }
        }

        [InlineData("ABC 123", 3)]
        [InlineData("AB12345", 5)]
        [InlineData("DEF 456", 2)]
        [Theory]
        public void SelectRegnr(string expectedRegNr, int count) {
            // arrange
            Handler handler = new Handler();
            Garage<IVehicle> garage = CreateGarageWithVehicles();
            try {
                //Act
                string regnr = handler.SelectRegnr(garage, count);

                //Assert
                Assert.Equal(expectedRegNr, regnr);
            } finally {
            }
        }

        public static Garage<IVehicle> CreateGarageWithVehicles() {
            Garage<IVehicle> garage = new Garage<IVehicle>(10);
            garage.Add(new Car("ABC 123", "Red", 1500, 5.2m, 2, 4));
            garage.Add(new Car("DEF 456", "Blue", 1600, 4.5m, 2, 4));
            garage.Add(new Bus("ABC 123", "Red", 1500, 5.2m, 2, 4));
            garage.Add(new Bus("DEF 456", "Blue", 1600, 4.5m, 2, 4));
            garage.Add(new Boat("AB12345", "Red", 15000, 14.2m, 2m, 14.6m, 25000m));
            garage.Add(new Boat("DE67890", "Blue", 16000, 17.5m, 2m, 12.2m, 26000m));
            return garage;
        }
    }
}