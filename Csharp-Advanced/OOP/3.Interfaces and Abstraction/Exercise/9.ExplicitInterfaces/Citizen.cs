namespace ExplicitInterfaces
{
    using Interfaces;
    public class Citizen : IPerson, IResident
    {
        public string Name { get; private set; }
        public string Country { get; private set; }
        public int Age { get; private set; }

        public Citizen(string name, string country, int age)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }

        string IPerson.GetName() => this.Name;
        string IResident.GetName() => $"Mr/Ms/Mrs {this.Name}";
    }
}
