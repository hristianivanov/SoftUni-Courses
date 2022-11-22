using System;
using System.Linq;
using System.Collections.Generic;

namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a program that reads N, a number representing rows and cols of a matrix.

            int n = int.Parse(Console.ReadLine());

            // On the next N lines, you will receive rows of the matrix.
            // Each row consists of ASCII characters. After that, you will receive a symbol.
            // Find the first occurrence of that symbol in the matrix and print its position in the format: "({row}, {col})".
            // If there is no such symbol print an error message
            //"{symbol} does not occur in the matrix "

            char[,] matrix = new char[n, n];


            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            char symbol = char.Parse(Console.ReadLine());

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row,col]==symbol)
                    {
                        Console.WriteLine($"({row}, {col})"); return;
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix ");


        }
    }
}
