using System;
using System.Collections.Generic;
using System.Text;

namespace _4.RandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random random = new Random();
            int index = random.Next(0, this.Count);

            string removed = this[index];

            this.RemoveAt(index);

            return removed;
        }
    }
}
