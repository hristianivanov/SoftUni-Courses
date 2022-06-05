using System;

namespace Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            int[] currentRow = new int[1];

            for (int row = 1; row <= numberOfRows; row++)
            {
                currentRow[0] = 1;
                int[] nextRow = new int[row + 1];
                for (int col = 0; col < row; col++)
                {
                    nextRow[col] += currentRow[col];
                    nextRow[col + 1] += currentRow[col];
                }
                Console.WriteLine(string.Join(" ", currentRow));
                currentRow = nextRow;
            }
        }
    }
}
