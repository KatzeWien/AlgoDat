using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            //    var sudoku = new char[,]
            //    {
            //{ '5', '3', '.', '.', '7', '.', '.', '.', '.' },
            //{ '6', '.', '.', '1', '9', '5', '.', '.', '.' },
            //{ '.', '9', '8', '.', '.', '.', '.', '6', '.' },
            //{ '8', '.', '.', '.', '6', '.', '.', '.', '3' },
            //{ '4', '.', '.', '8', '.', '3', '.', '.', '1' },
            //{ '7', '.', '.', '.', '2', '.', '.', '.', '6' },
            //{ '.', '6', '.', '.', '.', '.', '2', '8', '.' },
            //{ '.', '.', '.', '4', '1', '9', '.', '.', '5' },
            //{ '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            //    };
            //    solveSudoku(sudoku);
            int[,] field = new int[9, 9];
            int[,] sudoku = new int[,]
            {
        { 7, 1, 0, 5, 3, 0, 4, 8, 2 },
        { 2, 5, 0, 0, 0, 4, 0, 0, 0 },
        { 8, 6, 0, 9, 7, 2, 1, 3, 0 },
        { 1, 0, 0, 3, 6, 0, 0, 0, 0 },
        { 0, 0, 2, 0, 0, 0, 6, 0, 0 },
        { 0, 0, 0, 0, 9, 1, 0, 4, 3 },
        { 3, 0, 0, 0, 0, 9, 0, 0, 0 },
        { 0, 0, 1, 7, 0, 0, 0, 2, 6 },
        { 4, 0, 7, 0, 0, 0, 3, 5, 0 }
            };
            Test test = new Test();
            test.FillField(0, 0, 0, sudoku);
            Console.ReadLine();
        }
        public static void solveSudoku(char[,] board)
        {
            if (board == null || board.Length == 0)
                return;
            solve(board);
        }
        private static bool solve(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == '.')
                    {
                        for (char c = '1'; c <= '9'; c++)
                        {
                            if (isValid(board, i, j, c))
                            {
                                board[i, j] = c;

                                if (solve(board))
                                    return true;
                                else
                                    board[i, j] = '.';
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }
        private static bool isValid(char[,] board, int row, int col, char c)
        {
            for (int i = 0; i < 9; i++)
            {
                //check row  
                if (board[i, col] != '.' && board[i, col] == c)
                    return false;
                //check column  
                if (board[row, i] != '.' && board[row, i] == c)
                    return false;
                //check 3*3 block  
                if (board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] != '.' && board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] == c)
                    return false;
            }
            return true;
        }
    }
}
