﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace Take_Skip_Rope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<int> numbers = input
                .Where(x => char.IsDigit(x))
                .Select(x => x.ToString())
                .Select(int.Parse)
                .ToList();

            List<string> text = input
                .ToCharArray()
                .Where(x => x < '0' || x > '9')
                .Select(x => x.ToString())
                .ToList();

            List<int> takeList = numbers
                .Where((x, index) => index % 2 == 0)
                .ToList();

            List<int> skipList = numbers
                .Where((x, index) => index % 2 != 0)
                .ToList();

            string result = string.Empty;
            int index = 0;

            for (int i = 0; i < takeList.Count; i++)
            {
                List<string> symbol = text
                    .Skip(index)
                    .Take(takeList[i])
                    .ToList();

                result += string.Concat(symbol);
                index += takeList[i] + skipList[i];
            }

            Console.WriteLine(result);

        }
    }
}
