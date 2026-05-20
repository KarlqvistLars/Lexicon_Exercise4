using System.Globalization;

namespace Exercise4_Garage_2.Tests {
    public class UnitTestMenuClasses {
        [Fact]
        public void TestMenuAddVehicle() {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;
            Garage<IVehicle> garage = new Garage<IVehicle>(1);
            using var input = new StringReader("0\n\n");
            using var output = new StringWriter();
            Console.SetIn(input);
            Console.SetOut(output);

            try {
                // Act
                UI.MenuAddVehicle(garage);

                // Hämtar allt som skrivits till console
                string result = output.ToString();
                //StreamWriter sw = new StreamWriter("c:\\test1\\test_output.txt");
                //sw.Write(result);
                //sw.Close();

                Console.WriteLine(result);

                // Assert
                Assert.Contains($"   * Garage 2.0 * \r\n============================================================\r\n" +
                    $"   Add vehicle\r\n============================================================\r\n" +
                    $"1. Car\r\n" +
                    $"2. Bus\r\n" +
                    $"3. Motorcycle\r\n" +
                    $"4. Boat\r\n" +
                    $"5. Airplane\r\n" +
                    $"6. Random\r\n" +
                    $"0. Back\r\n\r\n\r\n\r\n   " +
                    $"Choose: ", result);

            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
                Console.Clear();
            }
        }

        [Fact]
        public void TestMenuRemoveVehicle() {
            //Arrange
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("sv-SE");
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;
            Garage<IVehicle> garage = new Garage<IVehicle>(1);
            using var input = new StringReader("2\n\n");
            using var output = new StringWriter();
            Console.SetIn(input);
            Console.SetOut(output);

            try {
                // Act
                UI.MenuRemoveVehicle(garage);

                string result = output.ToString();
                StreamWriter sw = new StreamWriter("c:\\test1\\test_output.txt");
                sw.Write(result);
                sw.Close();

                Console.WriteLine(result);

                // Assert
                Assert.Contains($"   * Garage 2.0 * \r\n" +
                    $"============================================================\r\n" +
                    $"   Remove vehicle\r\n" +
                    $"============================================================", result);

            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
                Console.Clear();
            }
        }
    }
}