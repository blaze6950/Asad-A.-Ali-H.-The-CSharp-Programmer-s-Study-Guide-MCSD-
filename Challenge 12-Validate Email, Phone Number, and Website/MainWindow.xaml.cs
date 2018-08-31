using System;
using System.Collections.Generic;
using System.IO;
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

namespace Challenge_12_Validate_Email__Phone_Number__and_Website
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GoCheck();
            }
            catch (IOException exception)
            {
                MessageBox.Show(exception.Message, "Ooops", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ooops", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }

        private void GoCheck()
        {
            if (!TextBoxEmail.Text.Equals("")
                && !TextBoxPhoneNumber.Text.Equals("")
                && !TextBoxDateOfBirth.Text.Equals("")
                && !TextBoxZipCode.Text.Equals("")
                && !TextBoxWebsite.Text.Equals(""))
            {
                ValidateInfo();
            }
            else
            {
                throw new IOException("Fill in all the fields!");
            }
        }

        private void ValidateInfo()
        {
            throw new NotImplementedException();
        }
    }
}
