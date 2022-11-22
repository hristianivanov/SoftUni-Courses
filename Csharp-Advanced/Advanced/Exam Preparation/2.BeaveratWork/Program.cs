using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.BeaveratWork
{
    public class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = ReadMatrixData(size);

            int startWoodCnt = GetStartingWoodCount(matrix);
            (int currRow, int currCol) = GetBeaverLocation(matrix);

            Stack<char> collectedBranches = new Stack<char>();

            string command;
            while (collectedBranches.Count != startWoodCnt && (command = Console.ReadLine().ToLower()) != "end")
            {
                int oldRow = currRow;
                int oldCol = currCol;
                switch (command)
                {
                    case "up": currRow--; break;
                    case "down": currRow++; break;
                    case "left": currCol--; break;
                    case "right": currCol++; break;
                }

                if (IsCellValid(currRow, currCol, matrix))
                {
                    if (matrix[currRow, currCol] == 'F')
                    {
                        matrix[currRow, currCol] = '-';
                        int lastIndex = size - 1;

                        if (currRow == lastIndex || currRow == 0 || currCol == lastIndex || currCol == 0)
                        {
                            switch (command)
                            {
                                case "up": currRow = lastIndex; break;
                                case "down": currRow = 0; break;
                                case "left": currCol = lastIndex; break;
                                case "right": currCol = 0; break;
                            }
                        }
                        else
                        {
                            switch (command)
                            {
                                case "up": currRow = 0; break;
                                case "down": currRow = lastIndex; break;
                                case "left": currCol = 0; break;
                                case "right": currCol = lastIndex; break;
                            }
                        }
                    }
                    if (matrix[currRow, currCol] == '-')
                    {
                        matrix[oldRow, oldCol] = '-';
                        matrix[currRow, currCol] = 'B';
                    }
                    else
                    {
                        collectedBranches.Push(matrix[currRow, currCol]);
                        matrix[oldRow, oldCol] = '-';
                        matrix[currRow, currCol] = 'B';
                    }
                }
                else
                {
                    currRow = oldRow;
                    currCol = oldCol;
                    if (collectedBranches.Any())
                    {
                        collectedBranches.Pop();
                        startWoodCnt--;
                    }
                }
            }
            if (!CheckForWood(matrix))
            {
                Console.WriteLine($"The Beaver successfully collect {collectedBranches.Count} wood branches: {string.Join(", ", collectedBranches.Reverse())}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {GetLeftBranches(matrix)} branches left.");
            }
            PrintMatrix(matrix);
        }
        private static char[,] ReadMatrixData(int size)
        {
            char[,] matrix = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                char[] line = Console.ReadLine().ToCharArray().Where(x => x != ' ').ToArray();
                for (int col = 0; col < line.Length; col++)
                    matrix[row, col] = line[col];
            }
            return matrix;
        }
        private static (int currRow, int currCol) GetBeaverLocation(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
                for (int col = 0; col < matrix.GetLength(1); col++)
                    if (matrix[row, col] == 'B')
                        return (row, col);
            return (0, 0);
        }
        private static int  GetStartingWoodCount(char[,] matrix)
        {
            int cnt = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
                for (int col = 0; col < matrix.GetLength(1); col++)
                    if (char.IsLower(matrix[row, col]))
                         cnt++;
            return cnt;
        }
        private static int GetLeftBranches(char[,] matrix)
        {
            int n = matrix.GetLength(0);
            int sum = 0;
            for (int row = 0; row < n; row++)
            {

                for (int col = 0; col < n; col++)
                {
                    if (char.IsLower(matrix[row, col]))
                    {
                        sum++;
                    }
                }
            }
            return sum;
        }
        private static bool CheckForWood(char[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (char.IsLower(matrix[row, col]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private static bool IsCellValid(int currRow, int currCol, char[,] matrix)
        {
            return currRow >= 0 && currRow < matrix.GetLength(0) &&
                currCol >= 0 && currCol < matrix.GetLength(1);
        }
        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int col = 0;
                for (col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.Write(matrix[row, col]);
                Console.WriteLine();
            }
        }
    }
}