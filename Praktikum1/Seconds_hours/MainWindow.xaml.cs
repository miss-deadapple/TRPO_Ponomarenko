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

namespace Seconds_hours
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox text = (TextBox)sender;
            if (((e.Key >= Key.D0) && (e.Key <= Key.D9) || (e.Key == Key.Back)
                 || (e.Key >= Key.NumPad0) && (e.Key <= Key.NumPad9))) return;
            if (e.Key == Key.OemComma && text.Text.IndexOf(",") == -1) return;
            e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str1 = text.Text;
            if (string.IsNullOrWhiteSpace(str1) != true)
            {
                double sec = Convert.ToDouble(str1);
                double hour = sec / 3600; string namehour;
                if (hour - (int)hour != 0) namehour = "часа";
                else if (hour % 100 > 10 && hour % 100 < 20) namehour = "часов";
                else if (hour % 10 == 1) namehour = "час";
                else if (hour % 10 >= 2 && hour % 10 < 5) namehour = "часа";
                else namehour = "часов";
                hours.Content = $"В указанном количестве секунд содержится {Math.Round(hour,2)} {namehour}";
            }
            else MessageBox.Show("Вы не указали количество секунд!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
