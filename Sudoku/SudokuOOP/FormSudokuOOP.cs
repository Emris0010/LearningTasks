using SudokuOOP.BusinessLogic;
using SudokuOOP.InfraContracts;
using System;
using System.Windows.Forms;

namespace SudokuOOP
{
    public partial class FormSudokuOOP : Form
    {

        private readonly ISudokuRepo sudokuRepo;
        private readonly CellsPanel cellsVM;

        public FormSudokuOOP(ISudokuRepo sudokuRepo)
        {
            InitializeComponent();

            this.sudokuRepo = sudokuRepo;
            var sudoku = sudokuRepo.Load();

            cellsVM = CellsPanel.Init(this, sudoku);
            cellsVM.SudokuChangedEvent += SudokuChanged_Event;
        }

        private void SudokuChanged_Event(object sender, EventArgs e)
        {
            sudokuRepo.Save(cellsVM.Sudoku);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (!cellsVM.Sudoku.IsFill)
            {
                MessageBox.Show("Решено не до конца");
                return;
            }

            if (!cellsVM.Sudoku.IsRight)
                MessageBox.Show("Верно");
            else
                MessageBox.Show("Неверно");
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            var sudoku = Sudoku.CreateNew(Level.Easy);
            cellsVM.NewSudoku(sudoku);
            sudokuRepo.Save(sudoku);
        }

    }
}
