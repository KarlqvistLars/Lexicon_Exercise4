namespace Exercise4_Garage_2b.Tests {
    public partial class UnitTest_Handler {



        [InlineData("k", " ", " ", " ")]
        [Theory]
        public void TestSaveAndLoadVehicles(string param1, string param2, string param3, string param4) {
            //Arrange
            TextReader originalIn = Console.In;
            TextWriter originalOut = Console.Out;
            string installationPath = Handler.GetInstallationPath();
            string fullPath = Path.Combine(installationPath, "saved_vehicles.txt");
            Handler handler = new Handler();
            Garage<IVehicle> garage = CreateGarageWithVehicles();
            using var input = new StringReader(param1 + "\n" + param2 + "\n" + param3 + "\n" + param4 + "\n");
            using var output = new StringWriter();
            try {
                Console.SetIn(input);
                Console.SetOut(output);
                //Act
                Handler.SaveVehicles(garage, fullPath);
                var result = handler.LoadVehicles(garage, fullPath);
                Garage<IVehicle> loadedGarage = result.Item2;
                string consolUtrskrift = output.ToString();
                //Assert
                Assert.Equal(loadedGarage[2].Uuid, garage[2].Uuid);
                Assert.Contains("6 st vehicle loaded from:", result.Item1);

                Assert.Contains("Sparar fordon till", consolUtrskrift);
                //Assert.Contains("Fordon sparade till file: saved_vehicles.txt", consolUtrskrift);
            } finally {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
                input.Close();
                output.Close();
            }
        }




    }
}