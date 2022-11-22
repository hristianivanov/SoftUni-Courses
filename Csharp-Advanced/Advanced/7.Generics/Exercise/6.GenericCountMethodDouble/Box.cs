using System;
using System.Collections.Generic;

namespace _6.GenericCountMethodDouble
{
    public class Box<T> where T : IComparable<T>
    {
        public Box()
        {
            Items = new List<T>();
        }
        public List<T> Items { get; set; }

        public int Count(T value)
        {
            int cnt = 0;
            foreach (var item in Items)
            {
                if (item.CompareTo(value) > 0)
                {
                    cnt++;
                }
            }
            return cnt;
        }
    }
}