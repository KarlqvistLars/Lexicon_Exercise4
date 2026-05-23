namespace Exercise4_Garage_2b.Tests {
    public partial class UnitTest_Handler {

        [InlineData("10", "y", "0", "0")]
        [InlineData("", "", "0", "0")]
        [Theory]
        public void TestStartGarage(string param1, string param2, string param3, string param4) {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;

            Handler handler = new Handler();
            using var input03 = new StringReader(param1 + "\n" + param2 + "\n" + param3 + "\n" + param4 + "\n");
            using var output03 = new StringWriter();

            try {
                Console.SetIn(input03);
                Console.SetOut(output03);

                // Act
                bool result03 = handler.StartGarage();
                // Assert
                var consolUtskr03 = output03.ToString();

                // kontrollera konsolutskriften, behöver vara false för att föra alla testfall samtidigt
                if (false) {
                    StreamWriter fileWriter = new StreamWriter("test_output.txt");
                    fileWriter.WriteLine(consolUtskr03);
                    fileWriter.Close();
                }

                Assert.True(result03);

                if (param1 == "10" && param2.ToLower() == "y") {
                    Assert.Contains("   * Garage 2.0 * \r\n=====================", consolUtskr03);
                    Assert.Contains("Press Enter to continue...", consolUtskr03);
                } else {
                    Assert.True(consolUtskr03.Contains("Programmet avslutas..."));
                    Assert.True(consolUtskr03.Contains("Vill du starta med ett fullt garage? (Y/N):"));
                }
            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
            }
        }
    }
}