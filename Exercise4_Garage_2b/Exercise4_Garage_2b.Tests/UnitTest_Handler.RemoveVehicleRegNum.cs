namespace Exercise4_Garage_2b.Tests {
    public partial class UnitTest_Handler {

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
                input.Close();
                output.Close();
            }
        }
    }
}