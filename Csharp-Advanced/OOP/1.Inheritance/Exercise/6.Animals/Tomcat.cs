using System;
using System.Collections.Generic;
using System.Text;

namespace _6.Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age) : base(name, age)
        {
        }

        public override string Gender { get => "Male";}
        public override string ProduceSound() => "MEOW";
    }
}
