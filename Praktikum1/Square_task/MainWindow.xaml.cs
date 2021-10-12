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

namespace Square_task
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            but.Content = new TextBlock() {Text= "Вычислить периметр и площадь квадрата", TextWrapping = TextWrapping.Wrap };
            text.Focus();
        }

        private void But_Click(object sender, RoutedEventArgs e)
        {
            string str = text.Text;
            double per, plo, st;
            if (string.IsNullOrWhiteSpace(str) != true)
            {
                st = Convert.ToDouble(str);
                per = st * 4;
                plo = st * st;
                lper.Content = $"Периметр квадрата равен {Math.Round(per,2)}";
                lplo.Content = $"Площадь квадрата равна {Math.Round(plo,2)}";
            }
            else MessageBox.Show("Вы не ввели сторону квадрата!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Text_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox text = (TextBox)sender;
            if (((e.Key >= Key.D0) && (e.Key <= Key.D9) || (e.Key == Key.Back)
                 || (e.Key >= Key.NumPad0) && (e.Key <= Key.NumPad9))) return;
            if (e.Key == Key.OemComma && text.Text.IndexOf(",") == -1) return;
            e.Handled = true;
        }
    }
}
