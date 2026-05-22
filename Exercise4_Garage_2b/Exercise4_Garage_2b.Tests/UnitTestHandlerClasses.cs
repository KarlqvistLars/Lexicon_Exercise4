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
        public void TestSelectRegnr(string expectedRegNr, int count) {
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
        [Fact]
        public void TestRemoveFromGarageList() {
            //Arrange
            Handler handler = new Handler();
            Garage<IVehicle> garage = CreateGarageWithVehicles();
            Vehicle vehicleToRemove = (Vehicle)garage[0];

            //Act
            var countBefore = garage.Count;
            bool result1 = handler.RemoveFromGarageList(garage, vehicleToRemove.Uuid);
            bool result2 = handler.RemoveFromGarageList(garage, "WWW 333");
            var countAfter = garage.Count;
            //Assert
            Assert.Equal(countBefore, 6);
            Assert.Equal(countAfter, 5);
            Assert.True(result1);
            Assert.False(result2);
        }
        [InlineData("", "", "", "", "2")]
        [InlineData("1", "", "", "", "2")]
        [InlineData("2", "", "", "", "4")]
        [InlineData("3", "", "", "", "jkl")]
        [InlineData("4", "", "", "", "6")]
        [InlineData("5", "", "", "", "1")]
        [Theory]
        public void TestRemoveVehicle_FoundAndRemoved(string param1, string param2, string param3, string param4, string param5) {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;

            Garage<IVehicle> g1 = CreateGarageWithVehicles();
            Garage<IVehicle> g2 = new Garage<IVehicle>(1);

            Handler handler = new Handler();
            var input = new StringReader(
                param1 + "\n" +
                param2 + "\n" +
                param3 + "\n" +
                param4 + "\n" +
                param5 + "\n"
            );

            using var output = new StringWriter();

            try {

                Console.SetIn(input);
                //Console.SetOut(output);

                //Act
                var countBefore = g1.Count;
                bool result = handler.RemoveVehicle(g1);
                bool result2 = handler.RemoveVehicle(g2);
                var countAfter = g1.Count;
                string consolUtrskrift = output.ToString();

                //Assert
                Assert.Equal(countBefore, 6);
                Assert.False(result2);
                if (param5 == "2") {
                    Assert.Equal(countAfter, 5);
                    Assert.True(result);

                } else {
                    Assert.Equal(countAfter, 6);
                    Assert.False(result);
                }

            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
            }
        }
        [Fact]
        public void TestRemoveVehicle_NotFound() {
            //Arrange
            var input = new StringReader("WWW 333");
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
                handler.RemoveVehicle(garage);
                var countAfter = garage.Count;
                string consolUtrskrift = output.ToString();
                //Assert
                Assert.Equal(countBefore, 6);
                Assert.Equal(countAfter, 6);
                Assert.False(consolUtrskrift.Contains("Hittade ingen fordon med det registreringsnumret"));
            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
            }
        }
        [InlineData("10", "y", "0", "0")]
        [InlineData("", "", "0", "0")]
        [Theory]
        public void TestStartGarage(string param1, string param2, string param3, string param4) {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;
            Handler handler = new Handler();
            using var input = new StringReader(param1 + "\n" + param2 + "\n" + param3 + "\n" + param4 + "\n");
            using var output = new StringWriter();
            try {
                Console.SetIn(input);
                Console.SetOut(output);
                // Act
                bool result = handler.StartGarage();
                // Assert
                var consolUtrskrift = output.ToString();
                StreamWriter fileWriter = new StreamWriter("test_output.txt");
                fileWriter.WriteLine(consolUtrskrift);
                fileWriter.Close();
                Console.WriteLine(consolUtrskrift);
                Assert.True(result);
                if (param1 == "10" && param2.ToLower() == "y") {
                    Assert.Contains("   * Garage 2.0 * \r\n=====================", consolUtrskrift);
                    Assert.Contains("Press Enter to continue...", consolUtrskrift);
                } else {
                    //Assert.True(consolUtrskrift.Contains("Programmet avslutas..."));
                    //Assert.True(consolUtrskrift.Contains("Vill du starta med ett fullt garage? (Y/N):"));
                }
            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
            }
        }
        [InlineData("k", " ", " ", " ")]
        [Theory]
        public void TestSaveAndLoadVehicles(string param1, string param2, string param3, string param4) {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;
            string installationPath = Handler.GetInstallationPath();
            string fullPath = Path.Combine(installationPath, "saved_vehicles.txt");
            Handler handler = new Handler();
            Garage<IVehicle> garage = CreateGarageWithVehicles();
            using var input = new StringReader(param1 + "\n" + param2 + "\n" + param3 + "\n" + param4 + "\n");
            using var output = new StringWriter();
            try {
                Console.SetIn(input);
                Console.SetOut(output);
                //Act
                Handler.SaveVehicles(garage, fullPath);
                var result = handler.LoadVehicles(garage, fullPath);
                Garage<IVehicle> loadedGarage = result.Item2;
                string consolUtrskrift = output.ToString();
                //Assert
                Assert.Equal(loadedGarage[2].Uuid, garage[2].Uuid);
                Assert.Contains("6 st vehicle loaded from:", result.Item1);

                Assert.Contains("Sparar fordon till", consolUtrskrift);
                //Assert.Contains("Fordon sparade till file: saved_vehicles.txt", consolUtrskrift);
            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
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