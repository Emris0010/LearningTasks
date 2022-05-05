using SudokuOOP.BusinessLogic;
using System.Drawing;
using System.Windows.Forms;

namespace SudokuOOP
{
    partial class CellsPanel
    {
        public static CellsPanel Init(Form parentControl, Sudoku sudoku)
        {
            var cellsVm = new CellsPanel(parentControl, sudoku);
            cellsVm.InitCells();
            cellsVm.RefillCells();
            return cellsVm;
        }


        private void InitCells()
        {
            for (int rowNum = 0; rowNum < 9; rowNum++)
            {
                for (int colNum = 0; colNum < 9; colNum++)
                {
                    InitCellTextBox(rowNum, colNum);
                }
            }
        }

        private void InitCellTextBox(int rowNum, int colNum)
        {
            var txb = new TextBox();
            txb.Font = new Font(txb.Font.FontFamily, 12);
            int x = colNum * 26 + 10;
            x += 2 * (colNum / 3);

            int y = rowNum * 26 + 10;
            y += 2 * (rowNum / 3);

            txb.Location = new Point(x, y);
            txb.TextAlign = HorizontalAlignment.Center;

            txb.Size = new Size(26, 26);
            txb.Tag = new Point(rowNum, colNum);

            txb.TextChanged += txb_TextChanged;

            textboxes[rowNum, colNum] = txb;
            parentControl.Controls.Add(txb);
        }
    }
}
