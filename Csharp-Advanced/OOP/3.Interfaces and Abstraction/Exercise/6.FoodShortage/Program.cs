
namespace FoodShortage.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;

    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<IBuyer> buyers = new HashSet<IBuyer>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = cmdArgs[0];
                int age = int.Parse(cmdArgs[1]);
                if (cmdArgs.Length == 3)
                {
                    string group = cmdArgs[2];
                    buyers.Add(new Rebel(name, age, group));
                }
                else
                {
                    string id = cmdArgs[2];
                    string birthdate = cmdArgs[3];
                    buyers.Add(new Citizen(id, name, age, birthdate));
                }

            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                if (buyers.Any(b => b.Name == input))
                    buyers.SingleOrDefault(b => b.Name == input).BuyFood();
            }

            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}
