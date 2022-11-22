namespace ExplicitInterfaces.Interfaces
{
    public interface IPerson
    {
        string Name { get; }
        int Age { get; }

        public string GetName();
    }
}
