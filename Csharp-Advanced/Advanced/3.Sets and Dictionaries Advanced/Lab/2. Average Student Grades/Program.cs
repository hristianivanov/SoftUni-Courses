using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var grades = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string name = input.Split().First();
                decimal grade = decimal.Parse(input.Split().Last());

                if (!grades.ContainsKey(name))
                {
                    grades.Add(name, new List<decimal>());
                }
                grades[name].Add(grade);
            }
            foreach (var name in grades)
            {
                Console.WriteLine($"{name.Key:f2} -> "
                    + string.Join(" ", name.Value.Select(x => $"{x:f2}"))
                    + $" (avg: {name.Value.Average():f2})");
            }
        }
    }
}
