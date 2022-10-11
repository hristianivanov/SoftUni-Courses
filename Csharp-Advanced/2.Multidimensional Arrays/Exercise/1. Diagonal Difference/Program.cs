using System;

namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(input[j]);
                }
            }


            var primary = 0;
            var secondary = 0;

            for (int i = 0; i < n; i++)
            {
                primary += matrix[i, i];
            }

            for (int i = 0; i < n; i++)
            {
                secondary += matrix[i, n - 1 - i];
            }

            Console.WriteLine(Math.Abs(primary-secondary));
        }
    }
}
