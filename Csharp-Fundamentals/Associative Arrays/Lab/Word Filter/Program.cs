using System;
using System.Linq;

namespace Word_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Where(x => x.Length % 2 == 0).ToArray();
            foreach (var item in input)
            {
                Console.WriteLine(item);
            }
        }
    }
}
