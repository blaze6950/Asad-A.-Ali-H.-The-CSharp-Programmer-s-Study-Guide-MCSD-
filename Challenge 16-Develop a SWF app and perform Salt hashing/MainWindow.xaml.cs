using System;
using System.Windows;
using System.Windows.Input;

namespace Challenge_16_Develop_a_SWF_app_and_perform_Salt_hashing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IDisposable
    {
        private RegisterLoginDb _registerLoginDb;
        private SignUpWindow _signUpWindow;

        public MainWindow()
        {
            InitializeComponent();
            _registerLoginDb = new RegisterLoginDb();
        }

        private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_signUpWindow == null)
            {
                _signUpWindow = new SignUpWindow(this);
            }
            Hide();
            _signUpWindow.ShowDialog();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (TextBoxLogin.Text.Length > 0 && PasswordBoxPassword.Password.Length > 0)
            {
                AccountInfo newAccountInfo = new AccountInfo();
                newAccountInfo.Login = TextBoxLogin.Text;
                newAccountInfo.Pass = PasswordBoxPassword.Password;
                if (_registerLoginDb.CheckLogin(newAccountInfo))
                {
                    MessageBox.Show("Successfully signed in!", "Great!", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Pls, check your login/password and try again or go sign up!", "Ooops!", MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields!", "Ooops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Dispose()
        {
            _registerLoginDb?.Dispose();
        }
    }
}
