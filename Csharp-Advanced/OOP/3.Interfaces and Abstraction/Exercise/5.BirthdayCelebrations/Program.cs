namespace BirthdayCelebrations.Models
{

    using System;
    using System.Collections.Generic;

    using Interfaces;

    public class Program
    {
        static void Main(string[] args)
        {
            List<IBirthdatable> entitties = new List<IBirthdatable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string type = cmdArgs[0];
                string name = cmdArgs[1];

                if (type == "Pet")
                {
                    string birthDate = cmdArgs[2];
                    entitties.Add(new Pet(name, birthDate));
                }
                else if (type == "Citizen")
                {
                    int age = int.Parse(cmdArgs[2]);
                    string id = cmdArgs[3];
                    string birthDate = cmdArgs[4];
                    entitties.Add(new Citizen(id, name, age, birthDate));
                }
            }

            string year = Console.ReadLine();

            entitties.ForEach(entity => entity.SearchBirthdateYear(year));

        }
    }
}
