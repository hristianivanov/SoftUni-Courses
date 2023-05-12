using System;
using System.Linq;
using System.Collections.Generic;


namespace Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> student = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();

                var grade = double.Parse(Console.ReadLine());

                if (student.ContainsKey(name))
                {
                    student[name].Add(grade);
                }
                else
                {
                    student.Add(name, new List<double>() { grade });
                }

            }
          
            //var a = student.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in student.Where(x => x.Value.Average() >= 4.5))
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");
            }

        }
    }
}
