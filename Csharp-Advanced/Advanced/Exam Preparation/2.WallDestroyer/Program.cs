using System;

namespace _2.WallDestroyer
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int currRow = 0;
            int currCol = 0;

            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = line[col];
                    if (matrix[row, col] == 'V')
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
            }
            int holes = 1;
            int rods = 0;

            matrix[currRow, currCol] = '*';

            bool isEletrocuted = false;

            string command;
            while ((command = Console.ReadLine()) != "End" && isEletrocuted == false)
            {

                int oldRow = currRow;
                int oldCol = currCol;
                switch (command)
                {
                    case "up":
                        currRow--;
                        break;
                    case "down":
                        currRow++;
                        break;
                    case "left":
                        currCol--;
                        break;
                    case "right":
                        currCol++;
                        break;
                }

                if (IsCellValid(currRow,currCol,matrix))
                {
                    char symbol = matrix[currRow, currCol];
                    switch (symbol)
                    {
                        case 'R':
                            rods++;
                            currRow = oldRow;
                            currCol = oldCol;
                            Console.WriteLine("Vanko hit a rod!"); break;
                        case 'C':
                            holes++;
                            isEletrocuted = true;
                            matrix[currRow, currCol] = 'E'; break;
                        case '-':
                            holes++;
                            matrix[currRow, currCol] = '*'; break;
                        case '*':
                            Console.WriteLine($"The wall is already destroyed at position [{currRow}, {currCol}]!"); break;
                    }
                }
                else
                {
                    currRow = oldRow;
                    currCol = oldCol;
                }
                
               
            }
            if (isEletrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
            }
            else
            {
                matrix[currRow, currCol] = 'V';
                Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {rods} rod(s).");
            }
            PrintMatrix(matrix);
        }
        private static bool IsCellValid(int row, int col, char[,] matrix)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(0);
        }
        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
