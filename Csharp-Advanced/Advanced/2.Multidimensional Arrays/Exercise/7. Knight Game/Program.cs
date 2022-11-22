using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] chess = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    chess[row, col] = line[col];
                }
            }

            int knightsRemoved = 0;
            while (true)
            { 
                int countMostAttacking = 0;
                int rowMostAttacking = 0;
                int colMostAttacking = 0;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (chess[row, col] == 'K')
                        {
                            int attackedKnights = CountAttackedKnights(row, col, n, chess);

                            if (countMostAttacking < attackedKnights)
                            {
                                countMostAttacking = attackedKnights;
                                rowMostAttacking = row;
                                colMostAttacking = col;
                            }
                        }
                    }
                }

                if (countMostAttacking == 0)
                {
                    break;
                }
                else
                {
                    chess[rowMostAttacking, colMostAttacking] = '0';
                    knightsRemoved++;
                }
            }

            Console.WriteLine(knightsRemoved);
        }

        static int CountAttackedKnights(int row, int col, int size, char[,] matrix)
        {
            int attackedKnights = 0;

            //horizontal left-up
            if (IsCellValid(row - 1, col - 2, size))
            {
                if (matrix[row - 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            //horizontal left-down
            if (IsCellValid(row + 1, col - 2, size))
            {
                if (matrix[row + 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            //horizontal right-up
            if (IsCellValid(row - 1, col + 2, size))
            {
                if (matrix[row - 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            //horizontal right-down
            if (IsCellValid(row + 1, col + 2, size))
            {
                if (matrix[row + 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            //vertical up-left
            if (IsCellValid(row - 2, col - 1, size))
            {
                if (matrix[row - 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            //vertical up-right
            if (IsCellValid(row - 2, col + 1, size))
            {
                if (matrix[row - 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            //vertical down-left
            if (IsCellValid(row + 2, col - 1, size))
            {
                if (matrix[row + 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            //vertical down-right
            if (IsCellValid(row + 2, col + 1, size))
            {
                if (matrix[row + 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            return attackedKnights;
        }


        static bool IsCellValid(int row, int col, int size)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }
    }
}
