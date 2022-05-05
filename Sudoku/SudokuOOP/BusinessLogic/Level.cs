namespace SudokuOOP.BusinessLogic
{
    public class Level
    {
        public int MinCount { get; private set; }

        private Level() { }

        public static Level Easy = new Level { MinCount = 30 };
        public static Level Medium = new Level { MinCount = 20 };
        public static Level Hard = new Level { MinCount = 10 };
    }
}
