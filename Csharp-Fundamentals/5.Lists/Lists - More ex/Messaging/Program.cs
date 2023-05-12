using System;
using System.Linq;

namespace Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string text = Console.ReadLine();
            
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write(GetLetter(text, nums[i]));
                int index = GetIndexOfChar(text, nums[i]);
                text = text.Remove(index, 1);
            }
           
        }

        private static int SumOfDigits(int num)
        {
            int sum = 0;
            while (num != 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }
        private static char GetLetter(string text, int num)
        {
            var index = 0;
            for (int i = 0; i < SumOfDigits(num); i++)
            {
                if (index == text.Length)
                {
                    index = 0;
                }
                index++;
            }

            return text[index];
        }

        private static int GetIndexOfChar(string text,int num)
        {
            var index = 0;
            for (int i = 0; i < SumOfDigits(num); i++)
            {
                if (index == text.Length)
                {
                    index = 0;
                }
                index++;
            }
            return index;
        }
    }
}
