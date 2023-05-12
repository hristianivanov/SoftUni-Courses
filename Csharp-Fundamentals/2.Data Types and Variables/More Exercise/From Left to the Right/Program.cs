using System;
using System.Numerics;
using System.Linq;


namespace From_Left_to_the_Right
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //If the left number is greater than the right number,
            //you need to print the sum of all digits in the left number,


            //otherwise, print the sum of all digits in the right number

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                long num1 = 0L;
                long num2 = 0L;

                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


                long leftNum = long.Parse(input[0]);
                long rightNum = long.Parse(input[1]);

                for (int k = 0; k < input[0].Length; k++)
                {
                    bool isDigit = long.TryParse(input[0][k].ToString(), out long digit);
                    num1 += digit;
                }

                for (int v = 0; v < input[1].Length; v++)
                {
                    bool isDigit = long.TryParse(input[1][v].ToString(), out long digit);
                    num2 += digit;
                }

                if (leftNum > rightNum)
                {
                    Console.WriteLine(num1);
                }
                else
                {
                    Console.WriteLine(num2);
                }
            }
        }
    }
}
