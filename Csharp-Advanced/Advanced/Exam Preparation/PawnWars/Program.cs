using System;

namespace _2.PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];
            for (int row = 0; row < 8; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < 8; col++)
                {
                    board[row, col] = line[col];
                }
            }

            (int whiteRow, int whiteCol) = GetWhitePawnPossition(board);
            (int blackRow, int blackCol) = GetBlackPawnPossition(board);


            bool whiteTurn = true;
            bool blackTurn = false;
            while (true)
            {

                if (whiteRow == 0)
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {GetChessBoardPossition(whiteRow,whiteCol)}.");
                    break;
                }
                else if (blackRow == 7)
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {GetChessBoardPossition(blackRow,blackCol)}.");
                    break;
                }



                if (IsWhiteCapture(whiteRow, whiteCol, board) && whiteTurn)
                {
                    Console.WriteLine($"Game over! White capture on {GetChessBoardPossition(blackRow,blackCol)}.");
                    break;
                }
                else if (IsBlackCapture(blackRow, blackCol, board) && blackTurn)
                {
                    Console.WriteLine($"Game over! Black capture on {GetChessBoardPossition(whiteRow,whiteCol)}.");
                    break;
                }


                if (whiteTurn)
                {
                    board[whiteRow, whiteCol] = '-';
                    whiteRow--;
                    board[whiteRow, whiteCol] = 'w';
                    whiteTurn = false;
                    blackTurn = true;
                    continue;
                }
                else if (blackTurn)
                {
                    board[blackRow, blackCol] = '-';
                    blackRow++;
                    board[blackRow, blackCol] = 'b';
                    whiteTurn = true;
                    blackTurn = false;
                    continue;
                }


            }
        }
        private static bool IsWhiteCapture(int row, int col, char[,] board)
        {
            bool diagonalUpLeft = false;
            bool diagonalUpRight = false;
            
            if (IsCellValid(row - 1, col - 1, board))
            {
                diagonalUpLeft = board[row - 1, col - 1] == 'b';
            }
            if (IsCellValid(row - 1, col + 1, board))
            {
                diagonalUpRight = board[row - 1, col + 1] == 'b';
            }
            return diagonalUpLeft || diagonalUpRight;
        }
        private static bool IsBlackCapture(int row, int col, char[,] board)
        {
            bool diagonalDowLeft = false;
            bool diagonalDownRight =  false;

            if (IsCellValid(row + 1, col - 1, board))
            {
                diagonalDowLeft = board[row + 1, col - 1] == 'w';
            }
            if (IsCellValid(row + 1, col + 1, board))
            {
                diagonalDownRight = board[row + 1, col + 1] == 'w';
            }
            return diagonalDowLeft || diagonalDownRight;
        }
        private static bool IsCellValid(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
        private static (int blackRow, int blackCol) GetBlackPawnPossition(char[,] board)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (board[row, col] == 'b')
                        return (row, col);
                }
            }
            return (0, 0);
        }
        private static (int whiteRow, int whiteCol) GetWhitePawnPossition(char[,] board)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (board[row, col] == 'w')
                        return (row, col);
                }
            }
            return (0, 0);
        }
        private static string GetChessBoardPossition(int row, int col)
        {
            string number=string.Empty;
            string letter=string.Empty;
            switch (row)
            {
                case 0: number = "8"; break;
                case 1: number = "7"; break;
                case 2: number = "6"; break;
                case 3: number = "5"; break;
                case 4: number = "4"; break;
                case 5: number = "3"; break;
                case 6: number = "2"; break;
                case 7: number = "1"; break;
            }
            switch (col)
            {
                case 0: letter = "a"; break;
                case 1: letter = "b"; break;
                case 2: letter = "c"; break;
                case 3: letter = "d"; break;
                case 4: letter = "e"; break;
                case 5: letter = "f"; break;
                case 6: letter = "g"; break;
                case 7: letter = "h"; break;
            }
            return $"{letter}{number}";
        }
    }
}
