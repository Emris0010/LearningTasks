using System;

namespace SudokuOOP.BusinessLogic
{
    partial class Sudoku
    {
        private class Factory
        {
            const int EMPTY_VALUE = 0;

            public Sudoku CreateNew(Level level)
            {
                var mtr = CreateBaseMatrix();
                Mix(mtr);
                DeleteSomeValues(mtr, level);

                return new Sudoku(ToData(mtr));
            }

            private Data ToData(int[,] mtr)
            {
                Data.Cell[,] values = new Data.Cell[9, 9];

                for (int rowNum = 0; rowNum < 9; rowNum++)
                    for (int colNum = 0; colNum < 9; colNum++)
                    {
                        if (mtr[rowNum, colNum] == EMPTY_VALUE)
                            values[rowNum, colNum] = new Data.Cell { IsBaseValue = false };
                        else
                            values[rowNum, colNum] = new Data.Cell { IsBaseValue = true, Value = mtr[rowNum, colNum] };
                    }

                return new Data { Values = values };
            }

            private int[,] CreateBaseMatrix()
            {
                var mtr = new int[9, 9];

                FillStr(mtr, 0, 1);
                FillStr(mtr, 1, 4);
                FillStr(mtr, 2, 7);

                FillStr(mtr, 3, 2);
                FillStr(mtr, 4, 5);
                FillStr(mtr, 5, 8);

                FillStr(mtr, 6, 3);
                FillStr(mtr, 7, 6);
                FillStr(mtr, 8, 9);

                return mtr;
            }

            private void Mix(int[,] mtr)
            {
                Random rnd = new Random();
                for (int rowNum = 0; rowNum < 100; rowNum++)
                {
                    // номера меняемых строк/столбцов
                    int n1 = rnd.Next(3);
                    int n2 = n1 + rnd.Next(3);
                    if (n2 > 2) n2 -= 3;
                    // номер меняемой большой строки/столбца
                    int N = rnd.Next(3);

                    // мешаем строку или столбец?
                    if (rnd.Next(1000) < 500)
                    {
                        ChangeColumns(mtr, N * 3 + n1, N * 3 + n2);
                    }
                    else
                    {
                        ChangeRows(mtr, N * 3 + n1, N * 3 + n2);
                    }
                }
            }

            private int?[,] ToValues(int[,] mtr)
            {
                var values = new int?[9, 9];
                for (int rowNum = 0; rowNum < 9; rowNum++)
                    for (int colNum = 0; colNum < 9; colNum++)
                        values[rowNum, colNum] = mtr[rowNum, colNum];
                return values;
            }

            private void FillStr(int[,] mtr, int rowNum, int firstValue)
            {
                for (int colNum = 0; colNum < 9; colNum++)
                {
                    int val = firstValue + colNum;
                    if (val > 9) val -= 9;
                    mtr[rowNum, colNum] = val;
                }
            }

            private void ChangeRows(int[,] mtr, int row1, int row2)
            {
                for (int colNum = 0; colNum < 9; colNum++)
                {
                    int c = mtr[row1, colNum];
                    mtr[row1, colNum] = mtr[row2, colNum];
                    mtr[row2, colNum] = c;
                }
            }

            private void ChangeColumns(int[,] mtr, int col1, int col2)
            {
                for (int rowNum = 0; rowNum < 9; rowNum++)
                {
                    int c = mtr[rowNum, col1];
                    mtr[rowNum, col1] = mtr[rowNum, col2];
                    mtr[rowNum, col2] = c;
                }
            }

            private void DeleteSomeValues(int[,] mtr, Level level)
            {
                Random rnd = new Random();

                while (DigitsCount(mtr) > level.MinCount)
                {
                    int rowNum = rnd.Next(9);
                    int colNum = rnd.Next(9);
                    mtr[rowNum, colNum] = EMPTY_VALUE;
                }
            }

            private int DigitsCount(int[,] mtr)
            {
                int digitsCount = 0;
                for (int rowNum = 0; rowNum < 9; rowNum++)
                    for (int colNum = 0; colNum < 9; colNum++)
                        if (mtr[rowNum, colNum] != EMPTY_VALUE)
                            digitsCount++;

                return digitsCount;
            }

        }
    }
}
