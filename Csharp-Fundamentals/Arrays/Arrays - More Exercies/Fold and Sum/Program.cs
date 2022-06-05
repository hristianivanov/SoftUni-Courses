using System;
using System.Collections.Generic;
using System.Linq;

namespace Fold_and_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var quaterLenth = input.Count / 4;

            var foldedNums = input.Skip(quaterLenth * 3).Reverse().ToList();

            foldedNums = new List<int>(input.Take(quaterLenth).Reverse().ToList().Concat(foldedNums));

            input = input.Skip(quaterLenth).Take(quaterLenth * 2).ToList();

            List<int> result = new List<int>();

            for (int i = 0; i < quaterLenth * 2; i++)
            {
                result.Add(input[i] + foldedNums[i]);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
