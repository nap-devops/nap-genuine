namespace Its.Jenuiue.Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                System.Threading.Thread.Sleep(10000);
                Console.WriteLine("Hello World!");
            }
        }
    }
}
