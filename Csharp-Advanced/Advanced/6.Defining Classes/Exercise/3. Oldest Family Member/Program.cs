using System;

namespace _3._Oldest_Family_Member
{
    public class Program
    {
        static void Main(string[] args)
        {
            Family family = new Family();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(input[0], int.Parse(input[1]));

                family.AddMember(person);
            }

            Person oldest = family.GetOldestMember();

            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}
