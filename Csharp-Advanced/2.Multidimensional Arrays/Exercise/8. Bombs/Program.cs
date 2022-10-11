using System;
using System.Linq;
using System.Collections.Generic;

namespace _8._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //90/100
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            var input = Console.ReadLine()
                .Split();

            for (int i = 0; i < input.Length; i++)
            {
                int bombRow = int.Parse(input[i].Split(',').First());

                int bombCol = int.Parse(input[i].Split(',').Last());

                if (IsCellValid(bombRow, bombCol, matrix))
                {
                    int value = matrix[bombRow, bombCol];
                    Exploding(matrix, bombRow, bombCol, value);
                    if (matrix[bombRow, bombCol] > 0)
                    {
                        matrix[bombRow, bombCol] = 0;
                    }
                }
            }

            int aliveCells = 0;
            int sum = 0;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }

        }

        private static void Exploding(int[,] matrix, int bombRow, int bombCol, int value)
        {
            if (value > 0)
            {
                //up
                if (IsCellValid(bombRow - 1, bombCol, matrix) && matrix[bombRow - 1, bombCol] > 0)
                {
                    var currentValue = matrix[bombRow - 1, bombCol];
                    matrix[bombRow - 1, bombCol] -= value;
                }
                //down
                if (IsCellValid(bombRow + 1, bombCol, matrix) && matrix[bombRow + 1, bombCol] > 0)
                {
                    var currentValue = matrix[bombRow + 1, bombCol];
                    matrix[bombRow + 1, bombCol] -= value;
                }
                //left
                if (IsCellValid(bombRow, bombCol - 1, matrix) && matrix[bombRow, bombCol - 1] > 0)
                {
                    var currentValue = matrix[bombRow, bombCol - 1];
                    matrix[bombRow, bombCol - 1] -= value;
                }
                //right
                if (IsCellValid(bombRow, bombCol + 1, matrix) && matrix[bombRow, bombCol + 1] > 0)
                {
                    var currentValue = matrix[bombRow, bombCol + 1];
                    matrix[bombRow, bombCol + 1] -= value;
                }
                //diagonal up left
                if (IsCellValid(bombRow - 1, bombCol - 1, matrix) && matrix[bombRow - 1, bombCol - 1] > 0)
                {
                    var currentValue = matrix[bombRow - 1, bombCol - 1];
                    matrix[bombRow - 1, bombCol - 1] -= value;
                }
                //diagonal up right
                if (IsCellValid(bombRow - 1, bombCol + 1, matrix) && matrix[bombRow - 1, bombCol + 1] > 0)
                {
                    var currentValue = matrix[bombRow - 1, bombCol + 1];
                    matrix[bombRow - 1, bombCol + 1] -= value;
                }
                //diagonal down left
                if (IsCellValid(bombRow + 1, bombCol - 1, matrix) && matrix[bombRow + 1, bombCol - 1] > 0)
                {
                    var currentValue = matrix[bombRow + 1, bombCol - 1];
                    matrix[bombRow + 1, bombCol - 1] -= value;
                }
                //diagonal down right
                if (IsCellValid(bombRow + 1, bombCol + 1, matrix) && matrix[bombRow + 1, bombCol + 1] > 0)
                {
                    var currentValue = matrix[bombRow + 1, bombCol + 1];
                    matrix[bombRow + 1, bombCol + 1] -= value;
                }
            }
        }

        public static bool IsCellValid(int row, int col, int[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
