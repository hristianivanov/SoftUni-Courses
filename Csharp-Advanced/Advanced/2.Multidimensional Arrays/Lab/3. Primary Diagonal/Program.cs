using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //square matrix 
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ').ToList();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(input[j]);
                }
            }

            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += matrix[i, i];
            }
            Console.WriteLine(sum);
        }
    }
}
