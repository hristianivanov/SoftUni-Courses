using System;
using System.Linq;

namespace demos
{
    internal class Program
    {
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
        static void Main(string[] args)
        {
            int[][] jaggedArr = new int[2][];
            int[] arr = new int[] { 2, 12, 1 };
            int[] arr1 = new int[] { 3, 124, 6 };
            int[] arr2 = new int[] { 6, 13244, 8 };
            jaggedArr[0] = arr;
            jaggedArr[1] = arr1;
            Console.WriteLine(10/2);
          
        }
    }
}
