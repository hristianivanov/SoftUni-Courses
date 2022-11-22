using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[,] matrix = new string[size, size];

            string[] commands = Console.ReadLine().Split();

            int coalCnt = 0;

            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine().Split();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == "c")
                    {
                        coalCnt++;
                    }
                }
            }

            var startRow = 0;
            var startCol = 0;

            int collectedCoal = 0;

            StartingPoint(size, matrix, ref startRow, ref startCol);

            foreach (string command in commands)
            {
                if (command == "up")
                {
                    if (IsCellValid(startRow - 1, startCol, matrix))
                    {
                        if (matrix[startRow - 1, startCol] == "e")
                        {
                            Console.WriteLine($"Game over! ({startRow - 1}, {startCol})"); return;
                        }
                        else if (matrix[startRow - 1, startCol] == "c")
                        {
                            collectedCoal++;
                            matrix[startRow - 1, startCol] = "*";
                            startRow = startRow - 1;
                        }
                        else
                        {
                            startRow = startRow - 1;
                        }
                    }
                }
                else if (command == "down")
                {
                    if (IsCellValid(startRow + 1, startCol, matrix))
                    {
                        if (matrix[startRow + 1, startCol] == "e")
                        {
                            Console.WriteLine($"Game over! ({startRow + 1}, {startCol})"); return;
                        }
                        else if (matrix[startRow + 1, startCol] == "c")
                        {
                            collectedCoal++;
                            matrix[startRow + 1, startCol] = "*";
                            startRow = startRow + 1;
                        }
                        else
                        {
                            startRow = startRow + 1;
                        }
                    }
                }
                else if (command == "left")
                {
                    if (IsCellValid(startRow, startCol - 1, matrix))
                    {
                        if (matrix[startRow, startCol - 1] == "e")
                        {
                            Console.WriteLine($"Game over! ({startRow}, {startCol - 1})"); return;
                        }
                        else if (matrix[startRow, startCol - 1] == "c")
                        {
                            collectedCoal++;
                            matrix[startRow, startCol - 1] = "*";
                            startCol = startCol - 1;
                        }
                        else
                        {
                            startCol = startCol - 1;
                        }
                    }
                }
                else if (command == "right")
                {
                    if (IsCellValid(startRow, startCol + 1, matrix))
                    {
                        if (matrix[startRow, startCol + 1] == "e")
                        {
                            Console.WriteLine($"Game over! ({startRow}, {startCol + 1})"); return;
                        }
                        else if (matrix[startRow, startCol + 1] == "c")
                        {
                            collectedCoal++;
                            matrix[startRow, startCol + 1] = "*";
                            startCol = startCol + 1;
                        }
                        else
                        {
                            startCol = startCol + 1;
                        }
                    }
                }
                if (collectedCoal == coalCnt)
                {
                    Console.WriteLine($"You collected all coals! ({startRow}, {startCol})"); return;
                }
            }

            Console.WriteLine($"{coalCnt - collectedCoal} coals left. ({startRow}, {startCol})");
        }

        private static void StartingPoint(int size, string[,] matrix, ref int startRow, ref int startCol)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == "s")
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
        }

        private static void PrintMatrix(int size, string[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsCellValid(int row, int col, string[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
