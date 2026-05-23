namespace Exercise4_Garage_2b.Tests {
    public class UnitTest_Car {

        [Theory]
        [InlineData("ABC 123", "Röd", 1500, 5.2, 2, 4)]
        [InlineData("DEF 456", "Blå", 1600, 4.8, 4, 4)]
        [InlineData("GHI 789", "Grön", 1400, 5.0, 2, 4)]
        [InlineData("JKL 012", "Svart", 1700, 4.5, 4, 4)]
        [InlineData("MNO 345", "Vit", 1500, 5.2, 2, 4)]
        [InlineData("PQR 678", "Gul", 1600, 4.8, 4, 4)]
        [InlineData("STU 901", "Orange", 1550, 5.0, 2, 4)]
        [InlineData("VWX 234", "Lila", 1650, 4.7, 4, 4)]
        [InlineData("YZA 567", "Rosa", 1500, 5.1, 2, 4)]
        [InlineData("BCD 890", "Brun", 1700, 4.6, 4, 4)]
        [InlineData("EFG 123", "Grå", 1600, 5.3, 2, 4)]
        public void TestCarClass(string in_id, string in_color, int in_weight, decimal in_length, int in_numberOfDoors, int in_wheels) {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;

            Vehicle car = new Car(in_id, in_color, in_weight, in_length, in_numberOfDoors, in_wheels);

            using var input = new StringReader("");
            using var output = new StringWriter();

            try {
                Console.SetIn(input);
                Console.SetOut(output);

                // Act
                Console.SetIn(input);
                var id = car.Uuid;
                var color = car.Color;
                var weight = car.Weight;
                var length = car.Length;
                var numberOfDoors = ((Car)car).NumberOfDoors;
                var wheels = ((Car)car).Wheels;
                bool result = id == in_id && color == in_color && weight == in_weight && length == in_length && numberOfDoors == in_numberOfDoors && wheels == in_wheels;
                string consolUtrskrift = car.ToString2(Utilities.VType.Car);

                // Assert
                Assert.True(result);
                Assert.Contains(in_id, consolUtrskrift);
                Assert.Contains(in_color, consolUtrskrift);
                Assert.Contains(in_weight.ToString(), consolUtrskrift);
                Assert.Contains(in_length.ToString(), consolUtrskrift);
                Assert.Contains(in_numberOfDoors.ToString(), consolUtrskrift);
                Assert.Contains(in_wheels.ToString(), consolUtrskrift);

            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
            }
        }
    }
}
