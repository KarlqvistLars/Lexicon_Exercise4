namespace Exercise4_Garage_2b.Tests {
    public partial class UnitTest_Handler {
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
    }
}