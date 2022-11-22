using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Person
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get => name; set => name = value; }
        public virtual int Age
        {
            get => age;
            set
            {
                if (value > 0) age = value;
            }
        }

        public override string ToString() => $"Name: {Name}, Age: {Age}";
    }

}

