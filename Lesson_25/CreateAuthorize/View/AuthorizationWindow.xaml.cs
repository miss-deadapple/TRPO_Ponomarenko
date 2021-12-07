using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CreateAuthorize.View
{
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private string oldFieldValue = "";
        
        private void CleanTextField_OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                var tb = sender as TextBox;
                if (tb.Text != "") oldFieldValue = tb.Text;
                tb.Text = "";
            }
        }

        private void ReturnTextField_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                var tb = sender as TextBox;
                if (tb.Text == "")
                {
                    tb.Text = oldFieldValue;
                } 
            }
        }

        private void GoToSignUp_OnClick(object sender, RoutedEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.Show();
        }

    }
}