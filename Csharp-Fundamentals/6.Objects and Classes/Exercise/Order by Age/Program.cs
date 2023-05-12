using System;
using System.Collections.Generic;
using System.Linq;

namespace Order_by_Age
{
    internal class Program
    {
        public class Person
        {
            public Person(string name, int id, int age)
            {
                Id = id;
                Name = name;
                Age = age;
            }

            public string Name { get; set; }
            public int Id { get; set; }
            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            List<Person> list = new List<Person>();

            while (input[0] != "End")
            {

                Person person = new Person(input[0],
                    int.Parse(input[1]),
                    int.Parse(input[2])
                    );

                list.Add(person);

                input = Console.ReadLine().Split();

            }
            
                foreach (var item in list.OrderBy(person => person.Age))
                {
                    Console.WriteLine($"{item.Name} with ID: {item.Id} is {item.Age} years old.");
                }
            
        }
    }
}
