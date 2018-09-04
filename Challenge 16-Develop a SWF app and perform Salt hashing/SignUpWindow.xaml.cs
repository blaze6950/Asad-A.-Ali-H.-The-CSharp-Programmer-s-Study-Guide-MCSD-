using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Challenge_16_Develop_a_SWF_app_and_perform_Salt_hashing
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : IDisposable
    {
        private RegisterLoginDb _registerLoginDb;
        private MainWindow _mainWindow;

        public SignUpWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _registerLoginDb = new RegisterLoginDb();
            _mainWindow = mainWindow;
        }

        private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_mainWindow == null)
            {
                _mainWindow = new MainWindow();
            }
            Hide();
            _mainWindow.ShowDialog();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (TextBoxLogin.Text.Length > 0 && PasswordBoxPassword.Password.Length > 0)
            {
                AccountInfo newAccountInfo = new AccountInfo();
                newAccountInfo.Login = TextBoxLogin.Text;
                newAccountInfo.Pass = PasswordBoxPassword.Password;
                if (_registerLoginDb.RegisterNewUser(newAccountInfo))
                {
                    MessageBox.Show("Successfully signed up!Now you can sign in!", "Great!", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Pls, check your login/password and try again or go sign in!", "Ooops!", MessageBoxButton.OK,
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

        private void SignUpWindow_OnClosing(object sender, CancelEventArgs e)
        {
            _mainWindow?.Close();
            this.Dispose();
        }
    }
}
