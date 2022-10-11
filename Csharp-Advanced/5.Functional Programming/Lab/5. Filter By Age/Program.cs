using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Filter_By_Age
{
    internal class Program
    {
        public class Person
        { 
            public string Name { get; set; }
            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            // Read the list of people (name + age)
            List<Person> people = ReadPeople();

            // Read the conditional + threshold
            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());
            Func<Person, bool> filter = CreatePersonFilter(condition, ageThreshold);

            // Filter all matching people by { conditional + threshold }
            List<Person> matchingPeople = people.Where(filter).ToList();

            // Print all matching people in the specified format
            string formatString = Console.ReadLine();
            Action<Person> printPerson = CreatePersonPrinter(formatString);
            PrintPeople(matchingPeople, printPerson);
        }

        static void PrintPeople(List<Person> people, Action<Person> printerPerson)
        {
            foreach (var person in people)
                printerPerson(person);
        }

        static Action<Person> CreatePersonPrinter(string format)
        {
            if (format == "name age")
                return p => Console.WriteLine($"{p.Name} - {p.Age}");
            if (format == "name")
                return p => Console.WriteLine($"{p.Name}")
                ; if (format == "age")
                return p => Console.WriteLine($"{p.Age}");

            throw new ArgumentException("Invalid: " + format);
        }

        static Func<Person, bool> CreatePersonFilter
           (string condition, int ageThreshold)
        {
            if (condition == "older")
                return p => p.Age >= ageThreshold;
            if (condition == "younger")
                return p => p.Age < ageThreshold;

            throw new ArgumentException($"Invalid filter: {condition} {ageThreshold}");
        }

        static List<Person> ReadPeople()
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(", ");
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                people.Add(new Person { Name = name, Age = age });
            }

            return people;
        }
    }
}

