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

namespace Random_numbers
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textBox1.Focus();
        }
        double x, y, z;

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox text = (TextBox)sender;
            if (((e.Key >= Key.D0) && (e.Key <= Key.D9) || (e.Key == Key.Back)
                 || (e.Key >= Key.NumPad0) && (e.Key <= Key.NumPad9))) return;
            if (e.Key == Key.OemMinus && text.Text.IndexOf("-") == -1 && text.SelectionStart == 0) return;
            e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str1 = textBox1.Text, str2=textBox2.Text;
            int a1, a2;
            if (string.IsNullOrWhiteSpace(str1) != true && string.IsNullOrWhiteSpace(str2) != true)
            {
                a1 = Convert.ToInt32(str1); a2 = Convert.ToInt32(str2);
                if (a1 < a2)
                {
                    Random r = new Random();
                    x = r.Next(a1, a2);
                    y = r.Next(a1, a2);
                    z = r.Next(a1, a2);
                    label.Content = x.ToString(); label_Copy.Content = y.ToString(); label_Copy1.Content = z.ToString();
                    button1.IsEnabled = true;
                }
                else MessageBox.Show("Вы перепутали начало и конец промежутка!","Ошибка!", MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
            else MessageBox.Show("Вы не ввели начало или конец промежутка!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            double srareph = (x + y + z) / 3;
            label_Copy2.Content = Math.Round(srareph, 2).ToString();
        }
    }
}
