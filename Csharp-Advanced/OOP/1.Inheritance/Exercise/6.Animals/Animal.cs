using System;
using System.Text;

namespace _6.Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;

        protected Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        protected Animal(string name,int age,string gender) : this(name, age)
        {
            Gender = gender;
        }

        public string Name
        {
            get => name;
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Invalid input!");
                name = value;
            }
        }

        public int Age
        {
            get => age;
            set
            {
                if (value <= 0) 
                    throw new ArgumentException("Invalid input!");
                age = value;
            }
        }
        public virtual string Gender { get; set; }
        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(this.GetType().Name);
            builder.AppendLine($"{Name} {Age} {Gender}");
            builder.Append(ProduceSound());

            return builder.ToString();
        }
    }
}
