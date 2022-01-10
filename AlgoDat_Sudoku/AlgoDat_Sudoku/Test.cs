using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_Sudoku
{
    class Test
    {
        public bool CheckRow (int zeile, int wert, int[,] field)
        {
            for (int i = 0; i < 9; i++)
            {
                if (field[i, zeile] == wert)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckColumn(int spalte, int wert, int[,] field)
        {
            for (int i = 0; i < 9; i++)
            {
                if (field[spalte, i] == wert)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckBlock(int zeile, int spalte, int wert, int[,] field)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (field[spalte - (spalte % 3) + i, zeile - (zeile % 3) + j] == wert)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckAll(int zeile, int spalte, int wert, int[,] field)
        {
            if (!CheckRow(zeile, wert, field))
            {
                return false;
            }
            if (!CheckColumn(spalte, wert, field))
            {
                return false;
            }
            if (!CheckBlock(zeile, spalte, wert, field))
            {
                return false;
            }
            return true;
        }

        public void Solve()
        {
            int[,] sudoku = new int[,]
            {
        { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
        { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
        { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
        { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
        { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
        { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
        { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
        { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
        { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
            };

            //CheckAll(0, 2, 5, sudoku);
            for (int zeile = 0; zeile < 9; zeile++)
            {
                Console.WriteLine();
                for (int spalte = 0; spalte < 9; spalte++)
                {
                    for (int wert = 1; wert < 10; wert++)
                    {
                        CheckAll(zeile, spalte, wert, sudoku);
                        Console.Write(wert);
                    }
                }
            }
        }

        public int[,] FillField(int wert, int row, int column, int[,] field)
        {
            int[,] currentField = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    currentField[j, i] = field[j, i];
                }
            }
            currentField[row, column] = wert;
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (currentField[x,y] == 0)
                    {
                        for (int input = 1; input <= 9; input++)
                        {
                            if (CheckAll(y,x,input,currentField))
                            {
                                FillField(input, x, y, currentField);
                            }
                        }
                        return null;
                    }
                }
            }
            return currentField;
        }

        public void PrintOut(int[,] field)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("--------");
        }
    }
}
