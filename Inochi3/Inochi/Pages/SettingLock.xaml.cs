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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UIKitTutorials;

namespace Inochi.Pages
{
    /// <summary>
    /// Interaction logic for SettingLock.xaml
    /// </summary>
    public partial class SettingLock : Page
    {
        public SettingLock()
        {
            InitializeComponent();
        }

        private void tblPass_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPass.Focus();
        }

        private void txtPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPass.Password) && txtPass.Password.Length > 0)
                tblPass.Visibility = Visibility.Collapsed;
            else
                tblPass.Visibility = Visibility.Visible;
        }

        private void btnSaveSetting_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPass.Password)) return;
            if (txtPass.Password == "70222555")
            {
                MainWindow.Instance.Navigate("Pages/SettingPage.xaml");
                Properties.Settings.Default.Save();

            }
            else
            {
                MessageBox.Show("Mật không chính xác", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
