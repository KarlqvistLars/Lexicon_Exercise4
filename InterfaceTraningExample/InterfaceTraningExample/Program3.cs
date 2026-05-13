namespace InterfaceTraningExample
{
    internal class Program3 : IStart, IStart2
    {
        public void Run()
        {
            Console.WriteLine("Nu kör vi program 3 i void-metoden");
        }

        int IStart2.Run()
        {
            Console.WriteLine("Nu kör vi program 3 och returnerar 7");
            return 7;
        }
    }
}
