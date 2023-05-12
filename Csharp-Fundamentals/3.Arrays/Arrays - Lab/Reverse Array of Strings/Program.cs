﻿using System;

namespace Reverse_Array_of_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Array.Reverse(elements);

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
