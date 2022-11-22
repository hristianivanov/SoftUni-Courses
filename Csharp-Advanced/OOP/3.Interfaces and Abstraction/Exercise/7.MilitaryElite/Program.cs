namespace MilitaryElite
{
    using Core;
    using Core.Interfaces;
    using IO;
    using IO.Interfaces;

    public class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
