using SudokuOOP.BusinessLogic;

namespace SudokuOOP.InfraContracts
{
    public interface ISudokuRepo
    {
        void Save(Sudoku sudoku);
        Sudoku Load();
    }
}
