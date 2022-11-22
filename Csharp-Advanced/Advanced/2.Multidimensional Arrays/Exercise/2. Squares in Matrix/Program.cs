using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split();

            int rows = int.Parse(sizes.First());
            int cols = int.Parse(sizes.Last());

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().Split();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = char.Parse(input[col]);
                }
            }
            var output = 0;
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1] && matrix[i, j] == matrix[i + 1, j] && matrix[i, j] == matrix[i + 1, j + 1])
                    {
                        output++;
                    }
                }
            }
            Console.WriteLine(output);
        }
    }
}
