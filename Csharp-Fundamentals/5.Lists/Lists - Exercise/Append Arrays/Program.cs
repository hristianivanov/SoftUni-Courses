﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var numbersAsStrings = Console.ReadLine().Split('|').Reverse().ToList();

            var numbers = new List<int>();
            foreach (var number in numbersAsStrings)
            {
                numbers.AddRange(number.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
