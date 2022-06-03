using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace praktikaArshinov
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region day1
        public double SolutionEquation(double a)
        {
            double z1 = (Math.Sin(4 * a) / (1 + Math.Cos(4 * a))) * (Math.Cos(2 * a) / (1 + Math.Cos(2 * a)));
            return z1;
        }
        public double SolutionEquation2(double a)
        {
            double z2 = Math.Cos(3 / 2 * Math.PI - a) / Math.Sin(3 / 2 * Math.PI - a);
            return z2;
        }
        public double SolutionEquation3(double x)
        {
            double y = 0;
            if (x >= -10 && x < -6)
                y = -1 * Math.Sqrt(4 - Math.Pow(+8, 2)) + 2;
            if (x >= -6 && x < -4)
                y = 2;
            if (x >= -4 && x < 2)
                y = (-1 * x) / 2;
            if (x >= 2 && x <= 4)
                y = x - 3;
            return y;
        }
        public void SolutionEquation4(double x, double y, double r, double a, double b)
        {
            if (a < r)
                MessageBox.Show("a не может быть меньше r");
            else if (b > r)
                MessageBox.Show("b не может быть больше r");
            else if (x * x + y * y <= r * r && x <= 0 && y <= 0 && y >= -1 * b)
            {
                MessageBox.Show("Входит");
            }
            else if (x * x + y * y >= r * r && x > 0 && y > 0 && x <= a && y <= b)
            {
                MessageBox.Show("Входит");
            }
            else MessageBox.Show("Не входит");

        }
        private void buttonForEquation1_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(textBoxForVariable1.Text);
                double result = SolutionEquation(a);
                textBoxForAnswer.Text = Convert.ToString(result);
                double a1 = Convert.ToDouble(textBoxForVariable2.Text);
                double result1 = SolutionEquation(a1);
                textBoxForAnswer2.Text = Convert.ToString(result1);
            }
            catch (Exception)
            {
                MessageBox.Show(" В первом уравнение данные введены неверно");
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                double arg = Convert.ToDouble(textBoxforQuestion2.Text);
                double result2 = SolutionEquation3(arg);
                textBoxForAnswer3.Text = Convert.ToString(result2);
            }
            catch (Exception)
            {
                MessageBox.Show("Значение введено неверно");

            }
        }
        private void buttonForStart_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(textBoxForX.Text);
                double y = Convert.ToDouble(textBoxForY.Text);
                double r = Convert.ToDouble(textBoxForR.Text);
                double a = Convert.ToDouble(textBoxForA.Text);
                double b = Convert.ToDouble(textBoxForB.Text);
                SolutionEquation4(x, y, r, a, b);
            }
            catch (Exception)
            {
                MessageBox.Show("Не правильно ввел");
            }
        }
        #endregion
        #region day 2
        public int[] FilingMassive(int[] mas)
        {
            listBoxFirsMatrix.Items.Clear();
            Random random = new Random();
            for (int i = 0; i < mas.Length; i++)
                mas[i] = random.Next(-10, 5);
            for (int i = 0; i < 2; i++)
            {
                mas[random.Next(0, mas.Length)] = 0;
            }

            return mas;

        }
        public int MaxElementMassive(int[] mas)
        {
            textBoxQuestion1.Clear();
            int max = mas[0];
            int index = 0;
            for (int i = 1; i < mas.Length; i++)
            {
                if (mas[i] > max)
                {
                    max = mas[i];
                    index = i;
                }
            }
            return index;
        }
        public int NullIndex(int[] mas)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            for (int i = 0; i < mas.Length; i++)
                if (mas[i] == 0)
                {
                    leftIndex = i;
                    break;
                }

            for (int i = mas.Length - 1; i >= 0; i--)
                if (mas[i] == 0)
                {
                    rightIndex = i;
                    break;
                }
            int proiz = 1;
            for (int i = leftIndex + 1; i < rightIndex; i++)
                proiz *= mas[i];
            return proiz;
        }
        public void NewMassive(int[] mas)
        {
            listBoxNextMassive.Items.Clear();
            int temp;
            for (int i = 0, j = 1; i < mas.Length / 2; i++, j += 2)
            {
                temp = mas[i];
                mas[i] = mas[j];
                mas[j] = temp;

            }


        }
        private void buttonToGo_Click_1(object sender, EventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(textBoxCountMassive.Text);
                int[] mas = new int[n];
                mas = FilingMassive(mas);
                for (int i = 0; i < mas.Length; i++)
                    listBoxFirsMatrix.Items.Add(mas[i]);
                textBoxQuestion1.Text = Convert.ToString(MaxElementMassive(mas));
                textBoxQuestion2.Text = Convert.ToString(NullIndex(mas));
                NewMassive(mas);
                for (int i = 0; i < mas.Length; i++)
                    listBoxNextMassive.Items.Add(mas[i]);
            }
            catch (Exception)
            {
                MessageBox.Show("введение неверно");
            }
        }
        #endregion
        #region day 3
        public void FirstMatrix(int n, int m)
        {
            dataGridViewMatrix.RowCount = n;
            dataGridViewMatrix.ColumnCount = m;
        }
        public int[,] CreateMatrix(int[,] mas, int n, int m)
        {
            FirstMatrix(n, m);
            dataGridViewMatrix.RowCount = n;
            dataGridViewMatrix.ColumnCount = m;
            Random random = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    mas[i, j] = random.Next(-15, 20);
                    dataGridViewMatrix.Rows[i].Cells[j].Value = Convert.ToString(mas[i, j]);
                }
            return mas;
        }
        public void MatrixTransformation(int[,] mas, int n, int m)
        {
            int flag = 1;
            while (flag == 1)
            {
                flag = 0;

                for (int i = 0; i < n - 1; i++)
                {
                    double sum1 = 0, sum2 = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (mas[j, i] < 0 && mas[j, i] % 2 != 0)
                        {
                            sum1 += Math.Abs(mas[j, i]);
                        }
                        if (mas[j, i + 1] < 0 && mas[j, i + 1] % 2 != 0)
                        {
                            sum2 += Math.Abs(mas[j, i + 1]);
                        }
                    }
                    if (sum1 > sum2)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            int tmp = mas[j, i];
                            mas[j, i] = mas[j, i + 1];
                            mas[j, i + 1] = tmp;
                        }
                        flag = 1;
                    }
                }
            }
            dataGridViewNewMatrix.RowCount = n;
            dataGridViewNewMatrix.ColumnCount = m;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    dataGridViewNewMatrix.Rows[i].Cells[j].Value = Convert.ToString(mas[i, j]);
                }

        }
        public int SumMas(int[,] mas, int n, int m)
        {

            listBoxSum.Items.Clear();
            for (int j = 0; j < m; j++)
            {
                int sum = 0;
                for (int i = 0; i < n; i++)
                {
                    if (mas[i, j] < 0)
                    {
                        for (int k = 0; k < n; k++)
                        {
                            sum += mas[k, j];

                            

                        }
                        listBoxSum.Items.Add($"Сумма столбца №{j}={sum}");
                        break;
                    }
                    
                }

            }

            return 1;
        }
        private void buttonForGo_Click_1(object sender, EventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(textBoxForLines.Text);
                int m = Convert.ToInt32(textBoxForColumns.Text);
                int[,] mas = new int[n, m];
                mas = CreateMatrix(mas, n, m);
                MatrixTransformation(mas, n, m);
                SumMas(mas, n, m);
            }
            catch (Exception)
            {
                MessageBox.Show("Неверно");
            }

        }
        #endregion
        #region day 4
        public class CountMonoblock
        {
            public int id { get; set; }
            public string model { get; set; }
            public string price { get; set; }
            public string brand { get; set; }


        }
        public List<CountMonoblock> countMonoblocks = new List<CountMonoblock>();
        public List<CountMonoblock> counts = new List<CountMonoblock>();
        public List<CountMonoblock> monoblocks = new List<CountMonoblock>();
        private void button1_Click(object sender, EventArgs e)
        {
            File.AppendAllText(@"C:\Users\Admin\Downloads\практика (1).txt", $"{countMonoblocks.Count + 1} {textBoxBrand.Text } {textBoxModel.Text} {textBoxPrice.Text}  ");
            CountMonoblock add = new CountMonoblock();
            add.id = countMonoblocks.Count + 1;
            add.brand = textBoxBrand.Text;
            add.model = textBoxModel.Text;
            add.price = textBoxPrice.Text;
            countMonoblocks.Add(add);
            dataGridViewFirstFile.DataSource = null;
            dataGridViewFirstFile.DataSource = countMonoblocks;
            textBoxBrand.Clear();
            textBoxModel.Clear();
            textBoxPrice.Clear();
        }

        private void textBoxForSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridViewNewFile.DataSource = countMonoblocks.Where(c => c.model.Contains(textBoxForSearch.Text) || c.brand.Contains(textBoxForSearch.Text) || c.price.Contains(textBoxForSearch.Text)).ToList();
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {
            string[] mas = File.ReadAllLines(@"C:\Users\Admin\Downloads\практика (1).txt");
            foreach (var items in mas)
            {
                CountMonoblock countMonoblock = new CountMonoblock();
                var g = items.Split(' ');
                countMonoblock.id = Convert.ToInt32(g[0]);
                countMonoblock.brand = Convert.ToString(g[1]);
                countMonoblock.model = Convert.ToString(g[2]);
                countMonoblock.price = Convert.ToString(g[3]);
                countMonoblocks.Add(countMonoblock);
                counts.Add(countMonoblock);
                monoblocks.Add(countMonoblock);
            }
            dataGridViewFirstFile.DataSource = countMonoblocks;
        }
        private void OutputInfoInDataGridView(List<CountMonoblock> list, DataGridView dataGridView)
        {
            dataGridView.DataSource = list;
        }

        public bool needToReOrder(string s1, string s2)
        {
            for (int i = 0; i < (s1.Length > s2.Length ? s2.Length : s1.Length); i++)
            {
                if (s1.ToCharArray()[i] < s2.ToCharArray()[i]) return false;
                if (s1.ToCharArray()[i] > s2.ToCharArray()[i]) return true;
            }
            return false;
        }

        public bool needToReOrderInt(int s1, int s2)
        {
            if (s1 > s2) return true;
            else return false;
        }

        public void SortByBrand(List<CountMonoblock> list, bool reverse)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count - 1; j++)
                {
                    if (needToReOrder(list[j].brand.ToLower(), list[j + 1].brand.ToLower()))
                    {
                        (list[j], list[j + 1]) = (list[j + 1], list[j]);
                    }
                }
            }
            dataGridViewNewFile.DataSource = null;
            if (reverse) list.Reverse();
            OutputInfoInDataGridView(list, dataGridViewNewFile);
        }
        public void SortByPrice(List<CountMonoblock> list, bool reverse)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count - 1; j++)
                {
                    if (needToReOrderInt(Convert.ToInt32(list[j].price), Convert.ToInt32(list[j + 1].price)))
                    {
                        (list[j], list[j + 1]) = (list[j + 1], list[j]);
                    }
                }
            }
            dataGridViewNewFile.DataSource = null;
            if (reverse) list.Reverse();
            OutputInfoInDataGridView(list, dataGridViewNewFile);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sort = comboBoxSort.SelectedIndex;
            int upperlower = comboBoxUpperLowerSort.SelectedIndex;

            if (upperlower != -1 && sort != -1)
            {

                if (sort == 0)
                {
                    if (upperlower == 0) SortByBrand(counts, false);
                    if (upperlower == 1) SortByBrand(counts, true);
                }
                else if (sort == 1)
                {
                    if (upperlower == 0) SortByPrice(monoblocks, false);
                    if (upperlower == 1) SortByPrice(monoblocks, true);

                }
            }
        }

        #endregion

        private void textBoxQuestion1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}








