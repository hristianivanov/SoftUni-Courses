using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _0.Demos
{
    public class Proram
    {

        public static void Main(string[] args)
        {
        }


        private static int CalculateSecondaryDiagonal(int[,] matrix)
        {
            int secondary = 0;
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                secondary += matrix[i, n - 1 - i];
            }

            return secondary;
        }
        private static int CalculatePrimaryDiagonal(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            var primary = 0;
            for (int i = 0; i < n; i++)
            {
                primary += matrix[i, i];
            }

            return primary;
        }
        static char[,] CopyMatrix(char[,] matrix)
        {
            char[,] copy = new char[matrix.GetLength(0), matrix.GetLength(1)];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    copy[row, col] = matrix[row, col];
                }
            }

            return copy;
        }
        private static void PrintMatrix(char[,] matrix,string separator)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + separator);
                }
                Console.WriteLine();
            }
        }
        static bool IsCellValid(int row, int col, char[,] matrix)
        {
            return row >= 0
                && row < matrix.GetLength(0)
                && col >= 0
                && col < matrix.GetLength(1);
        }
    }


}