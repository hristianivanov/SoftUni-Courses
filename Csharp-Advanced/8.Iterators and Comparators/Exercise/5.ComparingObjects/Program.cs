using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                Person person = new Person(data[0], int.Parse(data[1]), data[2]);
                people.Add(person);

            }
            int index = int.Parse(Console.ReadLine()) - 1;
            int equals = 0;
            int different = 0;
            foreach (var item in people)
            {
                if (item.CompareTo(people[index]) == 0)
                {
                    equals++;
                }
                else
                {
                    different++;
                }
            }
            if(equals == 1)
                Console.WriteLine("No matches");
            else
            Console.WriteLine($"{equals} {different} {people.Count}");

        }
    }
}
