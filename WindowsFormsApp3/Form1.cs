using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            int n;
            string inputN = textBoxN.Text;
            bool resultN = int.TryParse(inputN, out n);
            if (!resultN || n <= 1)
            {
                MessageBox.Show($"Введите число больше 1", "Ошибка");
                return;
            }

            grid.RowCount = n;
            grid.ColumnCount = n;

            var ran = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    grid.Rows[i].Cells[j].Value = ran.Next(-20, 21);
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var n = grid.ColumnCount;
            labelRes.Text = grid.Rows[1].Cells[1].Value.ToString();
            var s1 = 0;
            var s2 = 0;
            for (int i = 0; i < n; i++)
            {
                s1 += Int32.Parse(grid.Rows[i].Cells[i].Value.ToString());
                s2 += Int32.Parse(grid.Rows[i].Cells[n - 1 - i].Value.ToString());
            }

            if (s1 == s2)
            {
                labelRes.Text = "Сумма диагоналей равна";
            }
            else
            {
                labelRes.Text = s1 > s2 ? "Сумма главной диагонали больше" : "Сумма побочной диагонали больше";
            }
        }
    }
}
