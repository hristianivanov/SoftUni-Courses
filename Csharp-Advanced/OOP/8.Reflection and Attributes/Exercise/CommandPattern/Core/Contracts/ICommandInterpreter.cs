namespace CommandPattern.Core.Contracts
{
    public interface ICommandInterpreter
    {
        public string Read(string args);
    }
}
