using SudokuOOP.BusinessLogic;
using SudokuOOP.InfraContracts;
using System;
using System.IO;

namespace SudokuOOP
{
    class SudokuRepo : ISudokuRepo
    {
        private readonly string saveFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Save.save");

        public void Save(Sudoku sudoku)
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms))
            {
                for (int rowNum = 0; rowNum < 9; rowNum++)
                    for (int colNum = 0; colNum < 9; colNum++)
                    {
                        bw.Write(sudoku.IsBaseCell(rowNum, colNum));
                        bw.Write(sudoku.Value(rowNum, colNum) ?? 0);
                    }
                File.WriteAllBytes(saveFilePath, ms.ToArray());
            }

        }

        public Sudoku Load()
        {
            var values = new Sudoku.ValuesForCreate.Cell[9, 9];
            for (int rowNum = 0; rowNum < 9; rowNum++)
                for (int colNum = 0; colNum < 9; colNum++)
                    values[rowNum, colNum] = new Sudoku.ValuesForCreate.Cell { IsBaseValue = false, Value = null };

            if (!File.Exists(saveFilePath))
                return Sudoku.CreateFromStorage(new Sudoku.ValuesForCreate { Values = values });

            var buf = File.ReadAllBytes(saveFilePath);
            using (MemoryStream ms = new MemoryStream(buf))
            using (BinaryReader br = new BinaryReader(ms))
            {
                for (int rowNum = 0; rowNum < 9; rowNum++)
                {
                    for (int colNum = 0; colNum < 9; colNum++)
                    {
                        var isBaseValue = br.ReadBoolean();
                        var value = br.ReadInt32();

                        values[rowNum, colNum] = new Sudoku.ValuesForCreate.Cell
                        {
                            IsBaseValue = isBaseValue,
                            Value = value == 0 ? null : (int?)value
                        };
                    }
                }
            }

            return Sudoku.CreateFromStorage(new Sudoku.ValuesForCreate { Values = values });
        }
    }
}
