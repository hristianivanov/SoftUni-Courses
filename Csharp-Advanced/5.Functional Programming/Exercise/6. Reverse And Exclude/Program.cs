using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Reverse_And_Exclude
{
    internal class Program
    {
        public static Func<List<int>, Predicate<int>, List<int>> removeDivisible = (numbers, match) =>
        {
            List<int> result = new List<int>();

            foreach (var number in numbers)
            {
                if (match(number))
                {
                    result.Add(number);
                }
            }

            return result;
        };
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .Reverse()
                                .ToList();

            int num = int.Parse(Console.ReadLine());

            nums = removeDivisible(nums, n => n % num != 0);

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
