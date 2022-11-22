using System;
using System.Collections.Generic;
using System.Text;

namespace _7.Tuple
{
    public class Tuple<F,S>
    {
        public F FirstItem { get; set; }
        public S SecondItem { get; set; }

        public override string ToString()
        {
            return $"{FirstItem} -> {SecondItem}";
        }
    }
}
