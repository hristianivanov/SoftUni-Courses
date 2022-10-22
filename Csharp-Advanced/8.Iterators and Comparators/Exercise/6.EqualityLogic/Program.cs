using System;
using System.Collections.Generic;
using System.Globalization;

namespace _6.EqualityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> hashSet = new HashSet<Person>();
            SortedSet<Person> sortedSet = new SortedSet<Person>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(input[0], int.Parse(input[1]));

                hashSet.Add(person);
                sortedSet.Add(person);
            }
            Console.WriteLine(hashSet.Count);
            Console.WriteLine(sortedSet.Count);
        }
    }
}
