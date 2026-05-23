namespace Exercise4_Garage_2b.Tests {
    public partial class UnitTest_Handler {

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
    }
}