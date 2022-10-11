using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var availableFood = int.Parse(Console.ReadLine());

            var cmdArgs = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Queue<int> queue = new Queue<int>(cmdArgs);

            Console.WriteLine(queue.Max());
            for (int i = 0; i < cmdArgs.Count; i++)
            {
                if (queue.Any())
                {
                    var curr = queue.Peek();

                    if (availableFood-curr>=0)
                    {
                        availableFood-=curr;
                        queue.Dequeue();
                    }

                }

            }

            if (queue.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
