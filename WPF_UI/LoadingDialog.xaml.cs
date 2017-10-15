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

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for LoadingDialog.xaml
    /// </summary>
    public partial class LoadingDialog : UserControl
    {
        public LoadingDialog()
        {
            InitializeComponent();
            //InitByTask();
        }

        private void InitByTask()
        {
            var progress = new Progress<int>(value => LoadingBar.Value = value);
            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    ((IProgress<int>)progress).Report(i);
                    Thread.Sleep(50);
                }
            });
        }
    }
}
