using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MakingUIResponsive
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Task task = Task.Run(() =>
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    Label.Content = "Hello";
                }));
            });
            await task;
        }

        // ReSharper disable once UnusedMember.Local
        private Task MyWait(int milisec)
        {
            Task task = Task.Run(() =>
            {
                Thread.Sleep(milisec);
            });
            return task;
        }

        // ReSharper disable once UnusedMember.Local
        private async Task Normal_methodAsync()
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
