using System;
using System.Linq;

namespace _1._Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split(", ").ToList();

            int rows = int.Parse(sizes.First());
            int cols = int.Parse(sizes.Last());

            int[,] matrix = new int[rows,cols];

            for (int row = 0; row < rows; row++)
            {
                var nums = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = nums[col];
                }
            }

            int sum = 0;
            for (int row = 0; row < rows; row++)
            { 
                for (int col = 0; col < cols; col++)
                {
                    sum += matrix[row, col];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);

        }
    }
}
