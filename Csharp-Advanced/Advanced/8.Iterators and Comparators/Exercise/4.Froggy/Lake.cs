using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> data;
        private List<int> even;
        private List<int> odd;

        public Lake(List<int> data)
        {
            this.data = data;
            even = new List<int>();
            odd = new List<int>();
        }
        public void Print()
        {
            for (int i = 0; i < data.Count; i += 2)
            {
                odd.Add(data[i]);
            }
            for (int i = data.Count % 2 == 0 ? data.Count - 1 : data.Count - 2; i >= 0; i -= 2)
            {
                even.Add(data[i]);
            }
            var output = odd.Concat(even);
            Console.WriteLine(string.Join(", ",output));
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (i%2==0)
                {
                    yield return data[i];
                }
            }
            for (int i = data.Count - 1; i >= 0; i--)
            {
                if (i%2!=0)
                {
                    yield return data[i];
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
