using System;
using System.Linq;
using System.Collections.Generic;

namespace Students
{
    internal class Program
    {
        public class Student
        {
            public Student(string firstName,string lastName, double grade)
            {
                FirstName = firstName;
                LastName = lastName;
                Grade = grade;
            }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public double Grade { get; set; }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                Student student = new Student(input[0], input[1], double.Parse(input[2]));
                students.Add(student);
            }
            
            foreach (var item in students.OrderByDescending(x=>x.Grade))
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}: {item.Grade:f2}");
            }
        }
    }
}
