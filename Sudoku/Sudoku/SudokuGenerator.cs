using System;

namespace Sudoku
{
    static class SudokuGenerator
    {
        const int EASY_LEVEL_DIGITS_COUNT = 30;
        const int MEDIUM_LEVEL_DIGITS_COUNT = 20;
        const int HARD_LEVEL_DIGITS_COUNT = 10;

        public static int?[,] Generate(Level level)
        {
            var mtr = CreateBaseMatrix();

            Mix(mtr);

            var values = ToValues(mtr);

            DeleteSomeValues(values, level);

            return values;
        }

        private static int[,] CreateBaseMatrix()
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

        private static void Mix(int[,] mtr)
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

        private static int?[,] ToValues(int[,] mtr)
        {
            var values = new int?[9, 9];
            for (int rowNum = 0; rowNum < 9; rowNum++)
                for (int colNum = 0; colNum < 9; colNum++)
                    values[rowNum, colNum] = mtr[rowNum, colNum];
            return values;
        }

        private static void FillStr(int[,] mtr, int rowNum, int firstValue)
        {
            for (int colNum = 0; colNum < 9; colNum++)
            {
                int val = firstValue + colNum;
                if (val > 9) val -= 9;
                mtr[rowNum, colNum] = val;
            }
        }

        private static void ChangeRows(int[,] mtr, int row1, int row2)
        {
            for (int colNum = 0; colNum < 9; colNum++)
            {
                int c = mtr[row1, colNum];
                mtr[row1, colNum] = mtr[row2, colNum];
                mtr[row2, colNum] = c;
            }
        }

        private static void ChangeColumns(int[,] mtr, int col1, int col2)
        {
            for (int rowNum = 0; rowNum < 9; rowNum++)
            {
                int c = mtr[rowNum, col1];
                mtr[rowNum, col1] = mtr[rowNum, col2];
                mtr[rowNum, col2] = c;
            }
        }

        private static void DeleteSomeValues(int?[,] mtr, Level level)
        {
            Random rnd = new Random();

            var minCount = 0;
            switch (level)
            {
                case Level.Easy: minCount = EASY_LEVEL_DIGITS_COUNT; break;
                case Level.Medium: minCount = MEDIUM_LEVEL_DIGITS_COUNT; break;
                case Level.Hard: minCount = HARD_LEVEL_DIGITS_COUNT; break;
            }

            while (DigitsCount(mtr) > minCount)
            {
                int rowNum = rnd.Next(9);
                int colNum = rnd.Next(9);
                mtr[rowNum, colNum] = null;
            }
        }

        static int DigitsCount(int?[,] mtr)
        {
            int digitsCount = 0;
            for (int rowNum = 0; rowNum < 9; rowNum++)
                for (int colNum = 0; colNum < 9; colNum++)
                    if (mtr[rowNum, colNum].HasValue)
                        digitsCount++;

            return digitsCount;
        }

    }
}
