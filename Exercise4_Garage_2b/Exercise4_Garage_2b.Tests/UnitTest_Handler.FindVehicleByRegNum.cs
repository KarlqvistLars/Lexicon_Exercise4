namespace Exercise4_Garage_2b.Tests {
    public partial class UnitTest_Handler {

        [Fact]
        public void TestFindVehicleByRegNum() {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;
            Handler handler = new Handler();
            Garage<IVehicle> garage = CreateGarageWithVehicles();
            string regNumToFind = "AB12345";

            //Act
            var result = garage.FindByRegNumber(regNumToFind);
            //Assert
            Assert.NotNull(result);
            Assert.Equal(regNumToFind, result.Uuid);

            Console.SetIn(originalIn);
            Console.SetOut(originalOut);
        }
    }
}