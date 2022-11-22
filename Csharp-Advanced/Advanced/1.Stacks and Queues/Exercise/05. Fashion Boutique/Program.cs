using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int capacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(values);

            var racksCnt = 1;
            var capacityLeft = capacity;

            while (stack.Count > 0)
            {
                var currCloth = stack.Peek();

                if (currCloth <= capacityLeft)
                {
                    capacityLeft -= currCloth;
                    stack.Pop();
                }
                else
                {
                    racksCnt++;
                    capacityLeft = capacity;
                }
            }
            Console.WriteLine(racksCnt);
        }
    }
}


