namespace InterfaceTraningExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program1 p1 = new Program1();
            Program2 p2 = new Program2();
            Program3 p3 = new Program3();

            IStart[] programs = { p1, p2 };
            foreach (var program in programs)
            {
                program.Run();
            }
            ((IStart)p3).Run();
            int result = ((IStart2)p3).Run();
            Console.WriteLine($"Resultatet från program 3: {result}");

            string s1 = ((IString)p3).GetString();
            string vT = "program3 getstring";

            Console.WriteLine(s1.Equals(vT, StringComparison.OrdinalIgnoreCase));

        }
    }
}
