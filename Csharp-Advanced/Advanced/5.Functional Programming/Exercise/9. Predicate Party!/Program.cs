using System;
using System.Linq;
using System.Collections.Generic;

namespace _9._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToList();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] splitted = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = splitted[0];
                string filter = splitted[1];
                string value = splitted[2];

                if (action == "Remove")
                {
                    people.RemoveAll(GetPredicate(filter, value));
                }
                else
                {
                    List<string> collection = people.FindAll(GetPredicate(filter, value));

                    int index = people.FindIndex(GetPredicate(filter, value));

                    if (index >= 0)
                        people.InsertRange(index, collection);
                }
            }

            if (people.Any())
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "StartsWith":
                    return s => s.StartsWith(value);
                case "EndsWith":
                    return s => s.EndsWith(value);
                case "Length":
                    return s => s.Length == int.Parse(value);
                default:
                    return default(Predicate<string>);
            }
        }
    }
}
