using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Remoting;

namespace _6.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int CompareTo(Person other)
        {
            if (Name.CompareTo(other.Name) != 0)
            {
                return Name.CompareTo(other.Name);
            }

            return Age.CompareTo(other.Age);
        }
        public override bool Equals(object obj)
        {
            Person other = obj as Person;
            if (obj == null)
                return false;
            return  Name == other.Name && Age == other.Age;
        }

        public override int GetHashCode() => Name.GetHashCode() ^ Age.GetHashCode();
    }
}