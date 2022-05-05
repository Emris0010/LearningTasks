﻿namespace SudokuOOP.BusinessLogic
{
    partial class Sudoku
    {
        public class Data
        {
            public class Cell
            {
                public bool IsBaseValue;
                public int? Value;
            }

            public Cell[,] Values;
        }
    }
}
