using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Sort_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<int> nums = new List<int>();
            nums.Add(int.Parse(Console.ReadLine()));
            nums.Add(int.Parse(Console.ReadLine()));
            nums.Add(int.Parse(Console.ReadLine()));
            nums.Sort();nums.Reverse();

            foreach (var item in nums)
            {
                Console.WriteLine(item);
            }
        }
    }
}
