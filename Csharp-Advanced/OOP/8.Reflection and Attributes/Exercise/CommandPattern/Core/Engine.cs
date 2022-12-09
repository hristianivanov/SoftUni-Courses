namespace CommandPattern.Core
{
    using CommandPattern.IO;
    using Contracts;
    using IO.Contracts;
    using System;

    internal class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ICommandInterpreter cmdInterpreter;
        private Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }

        public Engine(ICommandInterpreter commandInterpreter)
            : this()
        {
            this.cmdInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string args = this.reader.ReadLine();
                    string result = this.cmdInterpreter.Read(args);
                    this.writer.WriteLine(result);
                }
                catch (InvalidOperationException ioe)
                {
                    this.writer.WriteLine(ioe.Message);
                }
            }
        }
    }
}
