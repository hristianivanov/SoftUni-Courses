using System;
using System.Linq;
using System.Collections.Generic;

namespace _8._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, HashSet<int>, List<int>> filter = (nums, diveders) =>
            {
                foreach (var diveder in diveders)
                {
                    nums = nums.Where(n => n % diveder == 0).ToList();
                }
                return nums;
            };

            int end = int.Parse(Console.ReadLine());
            var nums = Enumerable.Range(1, end).ToList();

            HashSet<int> diveders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToHashSet();

            //nums = filter(nums, diveders);
            foreach (var diveder in diveders)
            {
                nums = nums.Where(n => n % diveder == 0).ToList();
            }
            Console.WriteLine(String.Join(" ",nums));
        }
    }
}
