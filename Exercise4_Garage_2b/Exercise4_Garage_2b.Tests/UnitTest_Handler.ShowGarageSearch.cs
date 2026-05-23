using static Exercise4_Garage_2b.Utilities;

namespace Exercise4_Garage_2b.Tests {
    public partial class UnitTest_Handler {

        [Fact]
        public void TestShowGarageSearch() {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;

            Handler handler = new Handler();
            using var output01 = new StringWriter();

            Garage<IVehicle> tomtGarage = new Garage<IVehicle>(10);

            try {
                Console.SetOut(output01);

                //Act
                var result = handler.ShowGarageSearch(tomtGarage, VType.None, string.Empty, string.Empty, 0, 0);

                //Assert
                string consolUt = output01.ToString();
                // kontrollera konsolutskriften, behöver vara false för att föra alla testfall samtidigt
                if (false) {
                    StreamWriter fileWriter = new StreamWriter("test_output.txt");
                    fileWriter.WriteLine(consolUt);
                    fileWriter.Close();
                }

                Assert.False(result.Item1);
                //Assert.Contains("Garaget är tomt", consolUt);

            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
                //input.Close();
                output01.Close();
            }
        }
    }
}