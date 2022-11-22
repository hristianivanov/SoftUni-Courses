using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            string[,] matrix = new string[matrixSize[0], matrixSize[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                var input = command.Split();

                if (IsValidCommand(matrixSize, input))
                {
                    int row1 = int.Parse(input[1]);
                    int col1 = int.Parse(input[2]);
                    int row2 = int.Parse(input[3]);
                    int col2 = int.Parse(input[4]);

                    string tempValue = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = tempValue;

                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine();
            }
        }

        static void PrintMatrix(string[,] matrix)
        {

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        static bool IsValidCommand(int[] matrixSize, string[] input)
        {
            int row1 = 0;
            int col1 = 0;
            int row2 = 0;
            int col2 = 0;
            if (input.Length == 5)
            {
                row1 = int.Parse(input[1]);
                col1 = int.Parse(input[2]);
                row2 = int.Parse(input[3]);
                col2 = int.Parse(input[4]);
            }

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            return
                input[0] == "swap"
                && input.Length == 5
                && row1 >= 0 && row1 < rows
                && col1 >= 0 && col1 < cols
                && row2 >= 0 && row2 < rows
                && col2 >= 0 && col2 < cols;
        }
    }
}
