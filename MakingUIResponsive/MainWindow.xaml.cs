using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace MakingUIResponsive
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

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Task task = Task.Run(() =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Label.Content = "Hello";
                }));
            });
            await task;
        }

        private Task myWait(int milisec)
        {
            Task task = Task.Run(() =>
            {
                Thread.Sleep(milisec);
            });
            return task;
        }

        private async Task normal_methodAsync()
        {
            await DoComplicatedTaskAsync();
        }

        private Task<int> DoComplicatedTaskAsync()
        {
            var task = Task.Run(() => { Thread.Sleep(5000);
                return 15;
            });
            return task;
        }
    }
}
