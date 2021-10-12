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

namespace Random_Sum_Numbers
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            but.Content = new TextBlock() { Text = "Найти сумму и произведение цифр числа", TextWrapping = TextWrapping.Wrap };
        }
        int x, sumx, prox;

        private void But_Click(object sender, RoutedEventArgs e)
        {
            int x1 = x % 10, x2 = x / 10;
            sumx = x1 + x2; prox = x1 * x2;
            sum.Content = $"Сумма цифр равна {sumx}";
            proiz.Content = $"Произведение цифр равно {prox}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            x = r.Next(10, 99);
            num.Content = x.ToString();
        }
    }
}
