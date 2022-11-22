using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cmdArgs = Console.ReadLine()
                .Split();

            int n = int.Parse(cmdArgs[0]);
            int s = int.Parse(cmdArgs[1]);
            int x = int.Parse(cmdArgs[2]);

            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(nums);

            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Any() ? queue.Min() : 0);
            }
         
        }
    }
}
