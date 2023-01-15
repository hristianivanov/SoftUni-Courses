using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<int, int> nums = new Dictionary<int, int>();

            for (int i = 0; i < count; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (nums.ContainsKey(num))
                {
                    nums[num]++;
                    continue;
                }
                nums.Add(num, 1);
            }

            Console.WriteLine(nums.Single(num => num.Value % 2 == 0).Key);
        }
    }
}
