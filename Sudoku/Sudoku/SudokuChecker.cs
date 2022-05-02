using System.Collections.Generic;

namespace Sudoku
{
    static class SudokuChecker
    {
        public static bool IsFill(int?[,] values)
        {
            for (int rowNum = 0; rowNum < 9; rowNum++)
            {
                for (int colNum = 0; colNum < 9; colNum++)
                {
                    if (!values[rowNum,colNum].HasValue)
                        return false;
                }
            }
            return true;
        }

        public static bool IsRight(int?[,] values)
        {
            // смотрим строки
            for (int colNum = 0; colNum < 9; colNum++)
            {
                List<int> existedValues = new List<int>();
                for (int rowNum = 0; rowNum < 9; rowNum++)
                {
                    if (existedValues.Contains(values[rowNum, colNum].Value))
                        return false;
                    existedValues.Add(values[rowNum, colNum].Value);
                }
            }


            // смотрим столбцы
            for (int rowNum = 0; rowNum < 9; rowNum++)
            {
                List<int> existedValues = new List<int>();
                for (int colNum = 0; colNum < 9; colNum++)
                {
                    if (existedValues.Contains(values[rowNum, colNum].Value))
                        return false;
                    existedValues.Add(values[rowNum, colNum].Value);
                }
            }

            // смотрим квадраты
            for (int qX = 0; qX < 3; qX++)
                for (int qY = 0; qY < 3; qY++)
                {
                    List<int> existedValues = new List<int>();

                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 3; j++)
                        {
                            int rowNum = qX * 3 + i;
                            int colNum = qY * 3 + j;

                            if (existedValues.Contains(values[rowNum, colNum].Value))
                                return false;
                            existedValues.Add(values[rowNum, colNum].Value);
                        }
                }

            return true;
        }
    }
}
