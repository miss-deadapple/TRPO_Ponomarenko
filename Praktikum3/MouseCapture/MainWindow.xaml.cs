﻿using System;
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

namespace MouseCapture
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
        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point currentMouse = e.GetPosition(Rect);
                TextBlock1.Text = string.Format("x: {0} y:{1}", currentMouse.X,
               currentMouse.Y);
            }
        }
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs
       e)
        {
            if (IsCaptureMouse.IsChecked == true)
            {
                Rect.CaptureMouse();
            }
        }
        private void Rectangle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (IsCaptureMouse.IsChecked == true)
            {
                Rect.ReleaseMouseCapture();
            }
        }
    }
}
