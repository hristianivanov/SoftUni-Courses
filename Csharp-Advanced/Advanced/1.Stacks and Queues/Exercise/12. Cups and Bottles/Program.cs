using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> cups = GetInitialCups();
            Stack<int> bottles = GetInitialBottles();
            int wastedWater = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                int cup = cups.Pop();
                int bottle = bottles.Pop();
                cup -= bottle;
                if (cup <= 0)
                    wastedWater -= cup;
                else
                    cups.Push(cup);
            }

            if (cups.Count > 0)
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            else
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }

        static Stack<int> GetInitialCups()
        {
            Stack<int> cups = new Stack<int>();
            int[] cupsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = cupsInput.Length - 1; i >= 0; i--)
            {
                cups.Push(cupsInput[i]);
            }
            return cups;
        }

        static Stack<int> GetInitialBottles()
        {
            int[] bottlesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> bottles = new Stack<int>(bottlesInput);
            return bottles;
        }
    }
}

