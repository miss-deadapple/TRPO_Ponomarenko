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

namespace Katet_gipot_task
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            but.Content = new TextBlock() { Text = "Получить длину гипотенузы и площадь треугольника", TextWrapping = TextWrapping.Wrap };
        }
        int x1, x2, y1, y2;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str1=inter1.Text, str2=inter2.Text;
            Random r = new Random();
            if (string.IsNullOrWhiteSpace(str1) != true && string.IsNullOrWhiteSpace(str2) != true)
            {
                x1 = Convert.ToInt32(str1); x2 = Convert.ToInt32(str2);
                if (x1 < x2)
                {
                    y1 = r.Next(x1, x2);
                    y2 = r.Next(x1, x2);
                    katet1.Content = "Первый катет равен "+y1.ToString(); katet2.Content = "Второй катет равен "+y2.ToString();
                    but.IsEnabled = true;
                }
                else MessageBox.Show("Вы перепутали начало и конец промежутка!","Ошибка!",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            else MessageBox.Show("Вы не ввели начало и/или конец промежутка!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Inter1_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox text = (TextBox)sender;
            if (((e.Key >= Key.D0) && (e.Key <= Key.D9) || (e.Key == Key.Back)
                 || (e.Key >= Key.NumPad0) && (e.Key <= Key.NumPad9))) return;
            e.Handled = true;
        }

        private void But_Click(object sender, RoutedEventArgs e)
        {
            double gipote, pl;
            gipote = Math.Sqrt(y1*y1+y2*y2);
            pl = y1 * y2 / 2;
            gipot.Content = "Гипотенуза треугольника равна "+gipote.ToString();
            ploz.Content = "Площадь прямоугольного треугольника "+pl.ToString();
        }
    }
}
