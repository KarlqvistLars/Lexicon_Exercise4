namespace Exercise4_Garage_2b.Tests {
    public partial class UnitTest_Handler {



        [InlineData("1", "", "", "", "4")]
        [InlineData("1", "", "", "", "2")]
        [InlineData("2", "", "", "", "4")]
        [InlineData("3", "", "", "", "jkl")]
        [InlineData("4", "", "", "", "6")]
        [InlineData("5", "", "", "", "1")]
        //[Theory]
        public void TestRemoveVehicle_FoundAndRemoved(string param1, string param2, string param3, string param4, string param5) {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;

            Garage<IVehicle> g1 = CreateGarageWithVehicles();
            Garage<IVehicle> g2 = new Garage<IVehicle>(1);

            Handler handler = new Handler();
            var input = new StringReader(
                param1 + "\n" +
                param2 + "\n" +
                param3 + "\n" +
                param4 + "\n" +
                param5 + "\n"
            );

            using var output = new StringWriter();

            try {

                Console.SetIn(input);
                //Console.SetOut(output);

                //Act
                var countBefore = g1.Count;
                var countBefore2 = g2.Count;
                bool result = handler.RemoveVehicle(g1);
                bool result2 = handler.RemoveVehicle(g2);
                var countAfter = g1.Count;
                var countAfter2 = g2.Count;
                string consolUtrskrift = output.ToString();

                //Assert
                //Assert.Equal(countBefore, 6);
                Assert.Equal(countBefore2, 0);
                Assert.False(result2);

                Assert.Equal(countAfter, 5);
                Assert.True(result);

                Assert.Equal(countAfter2, 0);

            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
            }
        }
    }
}