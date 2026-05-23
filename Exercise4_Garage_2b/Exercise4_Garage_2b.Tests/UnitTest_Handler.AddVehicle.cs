using static Exercise4_Garage_2b.Utilities;

namespace Exercise4_Garage_2b.Tests {
    public partial class UnitTest_Handler {
        [Fact]
        public void TestAddVehicle() {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;
            Handler handler = new Handler();
            Garage<IVehicle> garageAdd = CreateGarageWithVehicles();
            var input02 = new StringReader("GHI 789\n3\n1700\n4,8\n2\n4\n");

            using var output02 = new StringWriter();
            string consolUtrskrift = output02.ToString();

            try {

                Console.SetIn(input02);
                Console.SetOut(output02);

                //Act
                int countBefore = garageAdd.Count;
                handler.AddVehicle(garageAdd, VType.Car);
                int countAfter = garageAdd.Count;

                //Assert
                Assert.Equal(countBefore + 1, countAfter);
            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
                input02.Close();
                output02.Close();
            }
        }
    }
}