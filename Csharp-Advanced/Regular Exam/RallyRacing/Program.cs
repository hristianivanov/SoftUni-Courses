using System;
using System.Linq;

namespace RallyRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string racingNumber = Console.ReadLine();

            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] line = Console.ReadLine().ToCharArray().Where(x => x != ' ').ToArray();
                for (int col = 0; col < line.Length; col++)
                    matrix[row, col] = line[col];
            }

            int currRow = 0;
            int currCol = 0;
            (int finishRow, int finishCol) = GetFinishLinePossition(matrix);
            int kilometersPassed = 0;


            string command;
            while ((command = Console.ReadLine()) != "End" && ReachFinishLine(matrix))
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

                char symbol = matrix[currRow, currCol];
                if (symbol == 'T')
                {
                    matrix[currRow, currCol] = '.';
                    (currRow, currCol) = GetThroughTheTunnel(matrix);
                    matrix[currRow, currCol] = '.';
                    kilometersPassed += 30;
                }
                else if (symbol == 'F')
                {
                    matrix[currRow, currCol] = 'C';
                    kilometersPassed += 10;
                }
                else if (symbol == '.')
                {
                    kilometersPassed += 10;
                }
            }
            if (ReachFinishLine(matrix))
            {
                matrix[currRow, currCol] = 'C';
                Console.WriteLine($"Racing car {racingNumber} DNF.");
            }
            else
            {
                Console.WriteLine($"Racing car {racingNumber} finished the stage!");
            }
            Console.WriteLine($"Distance covered {kilometersPassed} km.");
            PrintMatrix(matrix);
        }

        private static (int currRow, int currCol) GetThroughTheTunnel(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'T')
                        return (row, col);
                }
            }
            throw new Exception("don't find T");
        }

        private static (int finishRow, int finishCol) GetFinishLinePossition(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'F')
                        return (row, col);
                }
            }
            return (0, 0);
        }

        private static bool ReachFinishLine(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'F')
                        return true;
                }
            }
            return false;
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int col = 0;
                for (col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.Write(matrix[row, col]);
                Console.WriteLine();
            }
        }
    }
}
