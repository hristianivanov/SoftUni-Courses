﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.CustomComparator
{
    internal class Program
    {
        public class CustomComparator : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (x % 2 == 0 && y % 2 != 0)
                {
                    return -1;
                }

                if (x % 2 != 0 && y % 2 == 0)
                {
                    return 1;
                }

                return x.CompareTo(y);
            }
        }
        static void Main(string[] args)
        {
            Func<int, int, int> customComparator = (x, y) =>
            {
                if (x % 2 == 0 && y % 2 != 0)
                {
                    return -1;
                }

                if (x % 2 != 0 && y % 2 == 0)
                {
                    return 1;
                }

                return x.CompareTo(y);
            };

            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(numbers, new CustomComparator());

            Console.WriteLine(string.Join(" ", numbers));
        }

    }
    
}
