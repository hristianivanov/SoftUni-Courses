
namespace BirthdayCelebrations.Models
{
    using System;

    using Interfaces;

    public class Pet : IBirthdatable
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; private set; }
        public string Birthdate { get; private set; }

        public void SearchBirthdateYear(string year)
        {
            if (Birthdate.EndsWith(year))
                Console.WriteLine(Birthdate);
        }
    }
}
