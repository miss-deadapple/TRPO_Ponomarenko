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

namespace Variant1
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(input.Text != "0" && (Convert.ToInt32(input.Text) >= 10) && Convert.ToInt32(input.Text) <= 99)
            {
                int a = Convert.ToInt32(input.Text);
                if (a % 3 == 0)
                    multiplicity.Content = "Кратное 3";
                else
                    multiplicity.Content = "Не кратное 3";
                if(a%2 == 0)
                    parity.Content = "Четное";
                else
                    parity.Content = "Не четное";
                int sum = 0;
                int multi = 1;
                while (a != 0)
                {
                    multi *= a % 10;
                    sum += a % 10;
                    a /= 10;
                }
                sumtext.Content = "Сумма цифр: " + sum;
                multiplication.Content = "Произведение цифр: " + multi;
            }
            else
            {
                MessageBox.Show("Вы ввели не двузначное число");
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.Text, 0);
        }
    }
}
