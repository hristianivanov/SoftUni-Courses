﻿using System;

namespace Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int addedResult = AddNumbers(num1, num2);
            int finalResult = SubstractNumbers(addedResult, num3);
            PrintResult(finalResult);
        }

        private static int AddNumbers(int num1, int num2) => num1 + num2;
        private static int SubstractNumbers(int result, int num3) => result - num3;
        private static void PrintResult(int number) => Console.WriteLine(number);
    }
}
