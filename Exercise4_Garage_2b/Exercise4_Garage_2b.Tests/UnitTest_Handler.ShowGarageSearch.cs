using static Exercise4_Garage_2b.Utilities;

namespace Exercise4_Garage_2b.Tests {
    public partial class UnitTest_Handler {

        [Fact]
        public void TestShowGarageSearch() {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;

            Handler handler = new Handler();
            using var output = new StringWriter();

            Garage<IVehicle> tomtGarage = new Garage<IVehicle>(10);

            try {
                Console.SetOut(output);

                //Act
                var result = handler.ShowGarageSearch(tomtGarage, VType.None, string.Empty, string.Empty, 0, 0);

                //Assert
                string consolUtrskrift = output.ToString();
                // kontrollera konsolutskriften, behöver vara false för att föra alla testfall samtidigt
                if (false) {
                    StreamWriter fileWriter = new StreamWriter("test_output.txt");
                    fileWriter.WriteLine(consolUtrskrift);
                    fileWriter.Close();
                }

                Assert.False(result.Item1);
                Assert.True(consolUtrskrift.Contains("Garaget är tomt"));

            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
                //input.Close();
                output.Close();
            }
        }
    }
}