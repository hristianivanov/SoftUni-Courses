using System;
using System.Linq;

namespace Longest_Increasing_Subsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] len = new int[array.Length];
            int[] prev = new int[array.Length];
            int maxLen = 0;
            int lastIndex = -1;

            for (int currentIndex = 0; currentIndex < array.Length; currentIndex++)
            {
                len[currentIndex] = 1;
                prev[currentIndex] = -1;
                for (int previousIndex = 0; previousIndex < currentIndex; previousIndex++)
                {
                    if (array[previousIndex] < array[currentIndex] && (len[previousIndex] + 1 > len[currentIndex]))
                    {
                        len[currentIndex] = len[previousIndex] + 1;
                        prev[currentIndex] = previousIndex;
                    }
                }
                if (len[currentIndex] > maxLen)
                {
                    maxLen = len[currentIndex];
                    lastIndex = currentIndex;
                }
            }

            int[] reversedArray = new int[maxLen];
            reversedArray[0] = array[lastIndex];
            for (int i = 1; i < reversedArray.Length; i++)
            {
                int prevIndex = prev[lastIndex];
                reversedArray[i] = array[prevIndex];
                lastIndex = prevIndex;
            }

            for (int i = reversedArray.Length - 1; i >= 0; i--)
            {
                Console.Write($"{reversedArray[i]} ");
            }
        }
    }
}
