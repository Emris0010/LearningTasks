using System.Collections.Generic;

namespace SudokuOOP.BusinessLogic
{
    partial class Sudoku
    {
        private class Checker
        {
            public bool IsFill(SCell[,] cells)
            {
                for (int rowNum = 0; rowNum < 9; rowNum++)
                {
                    for (int colNum = 0; colNum < 9; colNum++)
                    {
                        if (!cells[rowNum, colNum].HasValue)
                            return false;
                    }
                }
                return true;
            }

            public bool IsRight(SCell[,] cells)
            {
                if (!RowsIsRight(cells)) return false;
                if (!ColumnsIsRight(cells)) return false;
                if (!SquareIsRight(cells)) return false;

                return true;
            }

            private bool RowsIsRight(SCell[,] cells)
            {
                for (int colNum = 0; colNum < 9; colNum++)
                {
                    List<int> existedValues = new List<int>();
                    for (int rowNum = 0; rowNum < 9; rowNum++)
                    {
                        if (existedValues.Contains(cells[rowNum, colNum].Value))
                            return false;
                        existedValues.Add(cells[rowNum, colNum].Value);
                    }
                }
                return true;
            }

            private bool ColumnsIsRight(SCell[,] cells)
            {
                for (int rowNum = 0; rowNum < 9; rowNum++)
                {
                    List<int> existedValues = new List<int>();
                    for (int colNum = 0; colNum < 9; colNum++)
                    {
                        if (existedValues.Contains(cells[rowNum, colNum].Value))
                            return false;
                        existedValues.Add(cells[rowNum, colNum].Value);
                    }
                }
                return true;
            }

            private bool SquareIsRight(SCell[,] cells)
            {
                for (int qX = 0; qX < 3; qX++)
                    for (int qY = 0; qY < 3; qY++)
                    {
                        List<int> existedValues = new List<int>();

                        for (int i = 0; i < 3; i++)
                            for (int j = 0; j < 3; j++)
                            {
                                int rowNum = qX * 3 + i;
                                int colNum = qY * 3 + j;

                                if (existedValues.Contains(cells[rowNum, colNum].Value))
                                    return false;
                                existedValues.Add(cells[rowNum, colNum].Value);
                            }
                    }

                return true;
            }
        }
    }
}
