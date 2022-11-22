using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split(", ").ToList();

            //3, 6
            //7 1 3 3 2 1
            //1 3 9 8 5 6
            //4 6 7 9 1 0

            int rows = int.Parse(sizes.First());
            int cols = int.Parse(sizes.Last());

            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var input = Console.ReadLine().Split(' ').ToList();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i,j] = int.Parse(input[j]);
                }
            }

            for (int i = 0; i < cols; i++)
            {
                int sum = 0;
                for (int j = 0; j < rows; j++)
                {
                    sum += matrix[j, i];
                }
                Console.WriteLine(sum);
            }

        }
    }
}
