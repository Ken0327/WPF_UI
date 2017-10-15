using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_UI
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

        private void OnButtonclick(object sender, RoutedEventArgs e)
    {
        PopupWindow popup = new PopupWindow();
        //ShowDialog means you can't focus the parent window, only the popup
        popup.ShowDialog(); //execution will block here in this method until the popup closes
        string name = popup.UserName;
        string passwd = popup.Password;
        UserNameTextBlock.Text = name;
        PasswordTextBlock.Text = passwd;
    }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;

            worker.RunWorkerAsync();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(1000);
            }
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            PbStatus.Value = e.ProgressPercentage;
        }

        private void Button_Click_Pb1(object sender, RoutedEventArgs e)
        {
            //Process();
        }

        private async Task Process()
        {
            try
            {
                var progress = new Progress<int>(value => PbStatus1.Value = value);
                await Task.Run(() =>
                {
                    for (int i = 0; i < 100; i++)
                    {
                        ((IProgress<int>)progress).Report(i);
                        Thread.Sleep(50);
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Button_Click_Pb(object sender, RoutedEventArgs e)
        {
            var loading = DialogHost.Show(new LoadingDialog(), "RootDialog");
            this.Dispatcher.Invoke((Action)(async () =>
            {
                await Process();
                rootdg.IsOpen = false;
            }));
        }
    }
}
