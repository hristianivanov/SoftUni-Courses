using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var range = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] nums = Enumerable.Range(range[0], range[1] - range[0] + 1).ToArray();

            bool isEven = Console.ReadLine() == "even";

            Predicate<int> even = (num) => num % 2 == 0;
            Predicate<int> odd = (num) => num % 2 != 0;
            Func<int[],Predicate<int>, int[]> EvenOdd = (nums,predicate) => nums.Where(n=>predicate(n)).ToArray();
 
            if (isEven)
            {
                Console.WriteLine(String.Join(" ",EvenOdd(nums,even)));
            }
            else
            {
                Console.WriteLine(String.Join(" ", EvenOdd(nums, odd)));
            }
        }
    }
}
