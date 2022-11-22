namespace BirthdayCelebrations.Models
{
    using System;

    using Interfaces;

    public class Citizen : IBirthdatable
    {
        public Citizen(string ID, string name, int age, string birthdate)
        {
            ID = ID;
            Name = name;
            Age = age;
            Birthdate = birthdate;
        }

        public string ID { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Birthdate { get; private set; }

        public void SearchBirthdateYear(string year)
        {
            if(Birthdate.EndsWith(year))
                Console.WriteLine(Birthdate);
        }
    }
}
