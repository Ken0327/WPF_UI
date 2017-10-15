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
using System.Windows.Shapes;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for PopupWindow.xaml
    /// </summary>
    public partial class PopupWindow : Window
    {
        public PopupWindow()
        {
            InitializeComponent();
        }

        public string UserName
        {
            get
            {
                if (txtResponse == null) return string.Empty;
                return txtResponse.Text;
            }
        }
        public string Password
        {
            get
            {
                if (txtPassword == null) return string.Empty;
                return txtPassword.Text;
            }
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            var password = txtPassword.Text;
            if ( password == "12345")
            {
                MessageBox.Show("Success");
                Close();
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }
    }
}
