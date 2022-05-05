using SudokuOOP.BusinessLogic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SudokuOOP
{
    partial class CellsPanel
    {
        public Sudoku Sudoku { get; private set; }
        public event EventHandler SudokuChangedEvent;

        private readonly TextBox[,] textboxes = new TextBox[9, 9];
        private readonly Form parentControl;

        private CellsPanel(Form parentControl, Sudoku sudoku)
        {
            this.parentControl = parentControl;
            Sudoku = sudoku;
        }

        bool bRefill = false;
        private void RefillCells()
        {
            bRefill = true;
            for (int rowNum = 0; rowNum < 9; rowNum++)
            {
                for (int colNum = 0; colNum < 9; colNum++)
                {
                    textboxes[rowNum, colNum].Text = Sudoku.Value(rowNum, colNum).ToString();
                    textboxes[rowNum, colNum].ReadOnly = Sudoku.IsBaseCell(rowNum, colNum);
                }
            }
            bRefill = false;
        }

        private void txb_TextChanged(object sender, EventArgs e)
        {
            if (bRefill)
                return;

            Point cellLocation = (Point)(sender as TextBox).Tag;
            int? value = null;
            if (int.TryParse((sender as TextBox).Text.Trim(), out var val))
                value = val;

            Sudoku.SetUserValue(cellLocation.X, cellLocation.Y, value);

            if (SudokuChangedEvent != null)
                SudokuChangedEvent(this, EventArgs.Empty);
        }

        internal void NewSudoku(Sudoku sudoku)
        {
            Sudoku = sudoku;
            RefillCells();
        }
    }
}
