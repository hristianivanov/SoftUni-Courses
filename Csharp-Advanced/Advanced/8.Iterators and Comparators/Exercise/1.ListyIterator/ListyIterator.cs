using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace _1.ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> items;
        private int index;

        public ListyIterator(List<T> items)
        {
            this.items = items;
        }
        public ListyIterator()
        {
            this.items = new List<T>();
        }

        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }
            return false;
        }
        public bool HasNext()
        {
            return index < items.Count - 1;
        }
        public void Print()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(items[index]);
        }

        public void Add(T item)
        {
            items.Add(item);
        }
    }


}

