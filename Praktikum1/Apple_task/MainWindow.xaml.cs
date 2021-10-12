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

namespace Apple_task
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            text1.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double x1, y1, x2, y2;
            string str1 = text1.Text, str2 = text2.Text, str3 = text3.Text;
            if (string.IsNullOrWhiteSpace(str1) != true && string.IsNullOrWhiteSpace(str2) != true && string.IsNullOrWhiteSpace(str3) != true)
            {
                x1 = Convert.ToDouble(str1); y1 = Convert.ToDouble(str2); x2 = Convert.ToDouble(str3);
                y2 = x2 * y1 / x1;
                apple.Content = $"Цена искомых яблок равна {Math.Round(y2,2)}";
            }
            else MessageBox.Show("Вы не ввели все данные!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox text = (TextBox)sender;
            if (((e.Key >= Key.D0) && (e.Key <= Key.D9) || (e.Key == Key.Back)
                 || (e.Key >= Key.NumPad0) && (e.Key <= Key.NumPad9))) return;
            if (e.Key == Key.OemComma && text.Text.IndexOf(",") == -1) return;
            e.Handled = true;
        }
    }
}
