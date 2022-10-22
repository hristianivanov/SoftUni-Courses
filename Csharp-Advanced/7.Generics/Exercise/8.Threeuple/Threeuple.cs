using System;
using System.Collections.Generic;
using System.Text;

namespace _8.Threeuple
{
    public class Threeuple<F,S,T>
    {
        public F FirstItem { get; set; }
        public S SecondItem { get; set; }
        public T ThirdItem { get; set; }

        public override string ToString()
        {
            return $"{FirstItem} -> {SecondItem} -> {ThirdItem}";
        }
    }
}
