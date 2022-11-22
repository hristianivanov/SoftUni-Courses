
namespace BorderControl.Models
{
    using System;

    using Interfaces;

    public class Citizen : IIdentifiable
    {
        public string Id { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public Citizen(string id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public void CheckId(string id)
        {
            if (this.Id.EndsWith(id))
                Console.WriteLine(this.Id);
        }
    }
}
