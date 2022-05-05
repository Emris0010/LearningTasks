using System;

namespace SudokuOOP.BusinessLogic
{
    partial class Sudoku
    {
        public class SCell
        {
            public bool IsBaseValue { get; private set; }

            private int? _value;
            public int Value => _value ?? throw new NullReferenceException("Чтение отсутствующего значения ячейки");
            public bool HasValue => _value.HasValue;

            public void SetUserValue(int? value)
            {
                if (IsBaseValue)
                    throw new InvalidOperationException("Попытка присвоения нового значения изначально заполненной ячейке");
                _value = value;
            }

            public static SCell CreateBaseValue(int? value)
            {
                return new SCell
                {
                    IsBaseValue = true,
                    _value = value
                };
            }

            public static SCell CreateUserValue(int? value)
            {
                return new SCell
                {
                    IsBaseValue = false,
                    _value = value
                };
            }
        }
    }
}
