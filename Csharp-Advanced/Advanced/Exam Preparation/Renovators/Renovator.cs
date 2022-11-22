using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Renovator
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Rate { get; set; }
        public int Days { get; set; }
        public bool Hired { get; set; }
        public Renovator(string name, string type, double rate, int days)
        {
            this.Name = name;
            this.Type = type;
            this.Rate = rate;
            this.Days = days;
        }



        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"-Renovator: {Name}");
            stringBuilder.AppendLine($"--Specialty: {Type}");
            stringBuilder.AppendLine($"--Rate per day: {Rate} BGN");
            return stringBuilder.ToString().Trim();
        }

    }
}
