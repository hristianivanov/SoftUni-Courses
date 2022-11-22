using System;
using System.Collections.Generic;
using System.Text;

namespace _1._Generic_Box_of_String
{
    public class Box<T>
    {
        public Box()
        {
            Items = new List<T>();
        }

        public List<T> Items { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in Items)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString();
        }
    }
}
