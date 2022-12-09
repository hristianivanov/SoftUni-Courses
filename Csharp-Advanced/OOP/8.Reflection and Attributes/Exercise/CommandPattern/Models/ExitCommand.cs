namespace CommandPattern.Models
{
    using Core.Contracts;
    using System;

    public class ExitCommand : ICommand
    {
        private const int DefaultErrorCode = 0;
        public string Execute(string[] args)
        {
            Environment.Exit(DefaultErrorCode);
            return null;
        }
    }
}
