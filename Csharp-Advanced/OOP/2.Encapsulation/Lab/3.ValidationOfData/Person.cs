using System;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName
        {
            get => firstName;
            private set
            {
                if (value.Length < 3) 
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                firstName = value;
            }
        }
        public string LastName
        {
            get => lastName;
            private set
            {
                if (value.Length < 3) 
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                lastName = value;
            }
        }
        public int Age 
        {
            get => age;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                age = value;
            }
        }
        public decimal Salary 
        {
            get => salary;
            private set
            {
                if (value < 650)
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                salary = value;
            }
        }

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