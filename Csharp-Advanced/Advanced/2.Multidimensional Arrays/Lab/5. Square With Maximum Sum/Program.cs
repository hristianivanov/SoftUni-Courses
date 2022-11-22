using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split(", ").ToList();

            int rows = int.Parse(sizes.First());
            int cols = int.Parse(sizes.Last());

            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var input = Console.ReadLine().Split(", ").ToList();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = int.Parse(input[j]);
                }
            }

            int max = 0;
            int startRow = 0;
            int startCol = 0;


            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    int sum = matrix[i, j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1];
                    if (sum > max)
                    {
                        max = sum;
                        startRow = i;
                        startCol = j;
                    }
                }
            }

            Console.WriteLine(matrix[startRow, startCol] + " " + matrix[startRow, startCol + 1]);
            Console.WriteLine(matrix[startRow + 1, startCol] + " " + matrix[startRow + 1, startCol + 1]);
            Console.WriteLine(max);
        }
    }
}
