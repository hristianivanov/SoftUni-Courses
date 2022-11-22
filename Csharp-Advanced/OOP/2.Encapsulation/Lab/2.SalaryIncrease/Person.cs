using System;

namespace PersonsInfo
{
    public class Person
    {
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName { get; private set; }
        public int Age { get; private set; }
        public string LastName { get; private set; }
        public decimal Salary { get; private set; }

        public void IncreaseSalary(decimal parcentage)
        {
            parcentage /= 100;
            if (Age < 30)
                Salary += Salary * (parcentage / 2);
            else
                Salary += Salary * parcentage;
        }
        public override string ToString() => $"{FirstName} {LastName} receives {Salary:f2} leva.";
    }
}