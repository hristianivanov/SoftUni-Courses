using System;

namespace Sum_Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // int.Parse(Console.ReadLine) = > "12345" => 12345 % 10 => 5
            // 12345 / 10 => 1234

            // first try to solve the problem
            //int numInput = int.Parse(Console.ReadLine());
            //int finalSum = 0;

            //while (numInput != 0)
            //{
            //    int lastDigit = numInput % 10;
            //    finalSum += lastDigit;
            //    numInput /= 10; 
            //}

            //Console.WriteLine(finalSum);

            // second try to solve the problem

            string input = Console.ReadLine();
            // char[] charArray = input.ToCharArray();
            int finalSum = 0;

            //for (int value = 0; value < charArray.Length; value++)
            //{
            //    finalSum += int.Parse(charArray[value].ToString());
            //}
            // third try
            for (int i = 0; i < input.Length; i++)
            {
                finalSum += int.Parse(input[i].ToString());
            }

            Console.WriteLine(finalSum);
        }
    }
}
