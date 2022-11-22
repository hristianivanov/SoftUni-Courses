using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Opinion_Poll
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split();

                Person person = new Person(input[0], int.Parse(input[1]));

                people.Add(person);
            }

            foreach (Person item in people.Where(x=>x.Age>30).OrderBy(x=>x.Name))
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
        }
    }
}
