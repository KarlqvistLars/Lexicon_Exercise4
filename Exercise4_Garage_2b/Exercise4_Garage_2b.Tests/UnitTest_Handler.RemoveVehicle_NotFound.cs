namespace Exercise4_Garage_2b.Tests {
    public partial class UnitTest_Handler {

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
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
                input.Close();
                output.Close();
            }
        }
    }
}