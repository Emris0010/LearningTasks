using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class FormSudoku : Form
    {
        private readonly TextBox[,] textboxes = new TextBox[9, 9];
        private readonly string saveFilePath = Path.Combine(Application.StartupPath, "Save.save");

        public FormSudoku()
        {
            InitializeComponent();
            RenderField();

            var values = LoadSudoku();
            RefillField(values);
        }

        private void RenderField()
        {
            for (int rowNum = 0; rowNum < 9; rowNum++)
            {
                for (int colNum = 0; colNum < 9; colNum++)
                {
                    AppendTextBox(rowNum, colNum);
                }
            }

        }

        private void RefillField(int?[,] values)
        {
            for (int rowNum = 0; rowNum < 9; rowNum++)
            {
                for (int colNum = 0; colNum < 9; colNum++)
                {
                    textboxes[rowNum, colNum].Text = values[rowNum, colNum].ToString();
                    textboxes[rowNum, colNum].ReadOnly = values[rowNum, colNum].HasValue;
                }
            }
        }

        private void AppendTextBox(int rowNum, int colNum)
        {
            var txb = new TextBox();

            int x = colNum * 22 + 10;
            x += 5 * (colNum / 3);

            int y = rowNum * 22 + 10;
            y += 5 * (rowNum / 3);

            txb.Location = new Point(x, y);
            txb.TextAlign = HorizontalAlignment.Center;

            txb.Size = new Size(20, 20);
            txb.Tag = new Point(rowNum, colNum);

            txb.TextChanged += txb_TextChanged;

            textboxes[rowNum, colNum] = txb;
            Controls.Add(txb);
        }

        private int?[,] GetValues()
        {
            int?[,] values = new int?[9, 9];

            for (int rowNum = 0; rowNum < 9; rowNum++)
            {
                for (int colNum = 0; colNum < 9; colNum++)
                {
                    values[rowNum, colNum] = GetValue(rowNum, colNum);
                }
            }

            return values;
        }

        private int? GetValue(int rowNum, int colNum)
        {
            if (int.TryParse(textboxes[rowNum, colNum].Text, out var val))
                return val;
            return null;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            var values = GetValues();

            if (!SudokuChecker.IsFill(values))
            {
                MessageBox.Show("Решено не до конца");
                return;
            }

            if (SudokuChecker.IsRight(values))
                MessageBox.Show("Верно");
            else
                MessageBox.Show("Неверно");
        }

        private void txb_TextChanged(object sender, EventArgs e)
        {
            var values = GetValues();
            SaveSudoku(values);
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            var values = SudokuGenerator.Generate(Level.Medium);
            RefillField(values);
            SaveSudoku(values);
        }

        private void SaveSudoku(int?[,] values)
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms))
            {
                for (int rowNum = 0; rowNum < 9; rowNum++)
                {
                    for (int colNum = 0; colNum < 9; colNum++)
                    {
                        bw.Write(values[rowNum, colNum] ?? 0);
                    }
                }
                File.WriteAllBytes(saveFilePath, ms.ToArray());
            }
        }

        private int?[,] LoadSudoku()
        {
            var values = new int?[9, 9];

            if (!File.Exists(saveFilePath))
                return values;

            var buf = File.ReadAllBytes(saveFilePath);
            using (MemoryStream ms = new MemoryStream(buf))
            using (BinaryReader br = new BinaryReader(ms))
            {
                for (int rowNum = 0; rowNum < 9; rowNum++)
                {
                    for (int colNum = 0; colNum < 9; colNum++)
                    {
                        var val  = br.ReadInt32();
                        if (val != 0)
                            values[rowNum, colNum] = val;
                    }
                }
            }

            return values;
        }
    }
}
