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

namespace Middle_Speed
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
            string str1 = text1.Text, str2 = text2.Text, str3 = text3.Text, str4 = text4.Text, str5 = text5.Text, str6 = text6.Text;
            if (string.IsNullOrWhiteSpace(str1) != true && string.IsNullOrWhiteSpace(str2) != true && string.IsNullOrWhiteSpace(str3) != true
                && string.IsNullOrWhiteSpace(str4) != true && string.IsNullOrWhiteSpace(str5) != true && string.IsNullOrWhiteSpace(str6) != true)
            {
                double v1 = Convert.ToDouble(str1), v2 = Convert.ToDouble(str3), v3 = Convert.ToDouble(str5), s1 = Convert.ToDouble(str2), s2 = Convert.ToDouble(str4),
                    s3 = Convert.ToDouble(str6);
                double sr = (s1 + s2 + s3) / (s1 * v1 + s2 * v2 + s3 * v3);
                sred.Content = new TextBlock() { Text=$"Средняя скорость автомобиля равна {Math.Round(sr, 2)}", TextWrapping= TextWrapping.Wrap };
            }
            else MessageBox.Show("Вы не ввели все значения длины пути и скорости авто!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Text1_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox text = (TextBox)sender;
            if (((e.Key >= Key.D0) && (e.Key <= Key.D9) || (e.Key == Key.Back)
                 || (e.Key >= Key.NumPad0) && (e.Key <= Key.NumPad9))) return;
            if (e.Key == Key.OemComma && text.Text.IndexOf(",") == -1) return;
            e.Handled = true;
        }
    }
}
