using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> nums = new Queue<int>(input);
            List<int> evenNumbers = new List<int>();

            while (nums.Count != 0)
            {
                int currentNumber = nums.Dequeue();
                if (currentNumber % 2 == 0)
                {
                    evenNumbers.Add(currentNumber);
                }
            }
            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
