namespace SudokuOOP.BusinessLogic
{
    public partial class Sudoku
    {
        private SCell[,] cells = new SCell[9, 9];
        private readonly Checker checker = new Checker();

        public bool IsFill => checker.IsFill(cells);
        public bool IsRight => checker.IsRight(cells);

        private Sudoku(ValuesForCreate data)
        {
            for (int rowNum = 0; rowNum < 9; rowNum++)
            {
                for (int colNum = 0; colNum < 9; colNum++)
                {
                    if (data.Values[rowNum, colNum].IsBaseValue)
                        cells[rowNum, colNum] = SCell.CreateBaseValue(data.Values[rowNum, colNum].Value);
                    else
                        cells[rowNum, colNum] = SCell.CreateUserValue(data.Values[rowNum, colNum].Value);
                }
            }
        }

        public int? Value(int rowNum, int colNum)
        {
            return cells[rowNum, colNum].HasValue ? (int?)cells[rowNum, colNum].Value : null;
        }

        public bool IsBaseCell(int rowNum, int colNum)
        {
            return cells[rowNum, colNum].IsBaseValue;
        }

        public void SetUserValue(int rowNum, int colNum, int? value)
        {
            cells[rowNum, colNum].SetUserValue(value);
        }

        public static Sudoku CreateNew(Level level)
        {
            return new Factory().CreateNew(level);
        }

        public static Sudoku CreateFromStorage(ValuesForCreate data)
        {
            return new Sudoku(data);
        }
    }
}
