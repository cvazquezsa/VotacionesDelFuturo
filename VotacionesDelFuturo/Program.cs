namespace VotacionesDelFuturo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.WriteLine("Bienvenido a las votaciones");
            new Votacion();

            Console.ReadLine();
        }
    }
}