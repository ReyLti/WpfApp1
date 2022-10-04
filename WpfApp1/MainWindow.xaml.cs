using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tb_Row.Text = "3";
            tb_Column.Text = "3";
        }

        private void btn_Answer_Click(object sender, RoutedEventArgs e)
        {
            tb_Output.Text = "";
            tb_Down.Text = "";
            tb_Up.Text = "";
            Random rnd = new Random();
            int[,] mas = new int[1,1];
            try
            {
                mas = new int[int.Parse(tb_Row.Text), int.Parse(tb_Column.Text)];
            }
            catch(FormatException) { MessageBox.Show("Неверный формат"); return; }
            catch(OverflowException) { MessageBox.Show("Кол-во строк и столбцов должны быть не менее 1");return; }
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for(int j = 0; j < mas.GetLength(1); j++)
                {
                    mas[i, j] = rnd.Next(-10, 10);
                }
            }
            PrintMatrix(mas, tb_Output);
            Sort(mas,true);
            tb_Max.Text = mas[mas.GetLength(0) - 1, mas.GetLength(1) - 1].ToString();
            tb_Min.Text = mas[0, 0].ToString();
            PrintMatrix(mas, tb_Up);
            Sort(mas, false);
            PrintMatrix(mas,tb_Down);
        }
        void PrintMatrix(int[,] matrix,TextBox tb)
        {
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j].ToString().Length == 1) tb.Text += "  "+matrix[i, j].ToString();
                    else tb.Text += " "+matrix[i, j].ToString();
                }
                tb.Text += Environment.NewLine;
            }
        }

        private void tb_Output_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        void Sort(int[,] matrix,bool m) //true по возрастанию, false по убыванию
        {
            int[] line = new int[matrix.Length];
            int k = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++,k++)
                {
                    line[k] = matrix[i, j];
                }
            }
            if (m) BubbleSortUp(line);
            else BubbleSortDown(line);
            k = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++,k++)
                {
                    matrix[i, j] = line[k];
                }
            }

        }
        int[] BubbleSortUp(int[] mas)
        {
            int temp;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] > mas[j])
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }
        int[] BubbleSortDown(int[] mas)
        {
            int temp;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] < mas[j])
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }
    }
}
