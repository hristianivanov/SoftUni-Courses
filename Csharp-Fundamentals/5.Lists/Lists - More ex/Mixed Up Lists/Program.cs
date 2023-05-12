using System;
using System.Collections.Generic;
using System.Linq;

namespace Mixed_Up_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //not mine
            List<int> firstCol = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondCol = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> mixesNumbers = new List<int>();
            int[] remainingNumbers = new int[2];

            GetRemainingNumbers(remainingNumbers, firstCol, secondCol);

            GetMixesNumbers(mixesNumbers, firstCol, secondCol);

            Array.Sort(remainingNumbers);
            List<int> output = mixesNumbers.FindAll(x => x > remainingNumbers[0] && x < remainingNumbers[1]);

            output.Sort();
            Console.WriteLine(string.Join(' ', output));
        }

        private static void GetRemainingNumbers(int[] remainingNumbers, List<int> firstCol, List<int> secondCol)
        {
            if (firstCol.Count > secondCol.Count)
            {
                remainingNumbers[0] = firstCol[firstCol.Count - 1];
                remainingNumbers[1] = firstCol[firstCol.Count - 2];
            }
            else
            {
                remainingNumbers[0] = secondCol[0];
                remainingNumbers[1] = secondCol[1];
            }
        }

        private static void GetMixesNumbers(List<int> mixesNumbers, List<int> firstCol, List<int> secondCol)
        {
            for (int i = 0; i < Math.Min(firstCol.Count, secondCol.Count); i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    mixesNumbers.Add(firstCol[i]);
                    mixesNumbers.Add(secondCol[secondCol.Count - 1 - i]);
                }
            }
        }
    }
}

