using System;

namespace Integer_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // input from the user 
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int divideNumber = int.Parse(Console.ReadLine());
            int multiplyNumber = int.Parse(Console.ReadLine());

            // logic for solving the problem
            // First try 
            //int sumNums = firstNumber + secondNumber;
            //int divisionResult = sumNums / divideNumber;
            //int multiplyResult = divisionResult * multiplyNumber;

            // Second try to solve the problem
            int finalResult = (firstNumber + secondNumber) / divideNumber * multiplyNumber;

            Console.WriteLine(finalResult);
        }
    }
}
