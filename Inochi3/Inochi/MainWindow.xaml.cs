using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Inochi.Pages;

namespace UIKitTutorials
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            this.Loaded += MainWindow_Loaded;
        }

        bool IsMaximized = false;
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //btnMenu.IsChecked = true;
            PagesNavigation.Navigate(new System.Uri("Pages/FirstPage.xaml", UriKind.RelativeOrAbsolute));

            //btn_FTPServer.Visibility = Visibility.Collapsed;
            //btnLocal.Visibility = Visibility.Collapsed;
            //btnSettings.Visibility = Visibility.Collapsed;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void rdHome_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/FtpPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdSounds_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/PcPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdNotes_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/SettingPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdPayment_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/FirstPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1280;
                    this.Height = 780;

                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximized = true;
                }
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có muốn thoát chương trình", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void btn_FTPServer_Click(object sender, RoutedEventArgs e)
        {
            var converter = new BrushConverter();
            btn_FTPServer.Background = (Brush)converter.ConvertFromString("#f7f6f4");
            btn_FTPServer.Foreground = (Brush)converter.ConvertFromString("#fb7657");

            btnDashboard.ClearValue(System.Windows.Controls.Button.BackgroundProperty);
            btnDashboard.ClearValue(System.Windows.Controls.Button.ForegroundProperty);

            btnLocal.ClearValue(System.Windows.Controls.Button.BackgroundProperty);
            btnLocal.ClearValue(System.Windows.Controls.Button.ForegroundProperty);

            btnSettings.ClearValue(System.Windows.Controls.Button.BackgroundProperty);
            btnSettings.ClearValue(System.Windows.Controls.Button.ForegroundProperty);

            //btnOpenApp.ClearValue(System.Windows.Controls.Button.BackgroundProperty);
            //btnOpenApp.ClearValue(System.Windows.Controls.Button.ForegroundProperty);

            //PagesNavigation.Navigate(new System.Uri("Pages/FtpPage.xaml", UriKind.RelativeOrAbsolute));
            PagesNavigation.Navigate(new System.Uri("Pages/PasswordPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            var converter = new BrushConverter();
            btnDashboard.Background = (Brush)converter.ConvertFromString("#f7f6f4");
            btnDashboard.Foreground = (Brush)converter.ConvertFromString("#fb7657");

            btn_FTPServer.ClearValue(System.Windows.Controls.Button.BackgroundProperty);
            btn_FTPServer.ClearValue(System.Windows.Controls.Button.ForegroundProperty);

            btnLocal.ClearValue(System.Windows.Controls.Button.BackgroundProperty);
            btnLocal.ClearValue(System.Windows.Controls.Button.ForegroundProperty);

            btnSettings.ClearValue(System.Windows.Controls.Button.BackgroundProperty);
            btnSettings.ClearValue(System.Windows.Controls.Button.ForegroundProperty);

            //btnOpenApp.ClearValue(System.Windows.Controls.Button.BackgroundProperty);
            //btnOpenApp.ClearValue(System.Windows.Controls.Button.ForegroundProperty);

            PagesNavigation.Navigate(new System.Uri("Pages/FirstPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnLocal_Click(object sender, RoutedEventArgs e)
        {
            var converter = new BrushConverter();
            btnLocal.Background = (Brush)converter.ConvertFromString("#f7f6f4");
            btnLocal.Foreground = (Brush)converter.ConvertFromString("#fb7657");

            btnDashboard.ClearValue(System.Windows.Controls.Button.BackgroundProperty);
            btnDashboard.ClearValue(System.Windows.Controls.Button.ForegroundProperty);

            btn_FTPServer.ClearValue(System.Windows.Controls.Button.BackgroundProperty);
            btn_FTPServer.ClearValue(System.Windows.Controls.Button.ForegroundProperty);

            btnSettings.ClearValue(System.Windows.Controls.Button.BackgroundProperty);
            btnSettings.ClearValue(System.Windows.Controls.Button.ForegroundProperty);

            //btnOpenApp.ClearValue(System.Windows.Controls.Button.BackgroundProperty);
            //btnOpenApp.ClearValue(System.Windows.Controls.Button.ForegroundProperty);

            PagesNavigation.Navigate(new System.Uri("Pages/PcPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            var converter = new BrushConverter();
            btnSettings.Background = (Brush)converter.ConvertFromString("#f7f6f4");
            btnSettings.Foreground = (Brush)converter.ConvertFromString("#fb7657");

            btnDashboard.ClearValue(System.Windows.Controls.Button.BackgroundProperty);
            btnDashboard.ClearValue(System.Windows.Controls.Button.ForegroundProperty);

            btn_FTPServer.ClearValue(System.Windows.Controls.Button.BackgroundProperty);
            btn_FTPServer.ClearValue(System.Windows.Controls.Button.ForegroundProperty);

            btnLocal.ClearValue(System.Windows.Controls.Button.BackgroundProperty);
            btnLocal.ClearValue(System.Windows.Controls.Button.ForegroundProperty);

            //btnOpenApp.ClearValue(System.Windows.Controls.Button.BackgroundProperty);
            //btnOpenApp.ClearValue(System.Windows.Controls.Button.ForegroundProperty);

            PagesNavigation.Navigate(new System.Uri("Pages/SettingLock.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnOpenApp_Click(object sender, RoutedEventArgs e)
        {
            var converter = new BrushConverter();
            //btnOpenApp.Background = (Brush)converter.ConvertFromString("#f7f6f4");
            //btnOpenApp.Foreground = (Brush)converter.ConvertFromString("#fb7657");

            btnDashboard.ClearValue(System.Windows.Controls.Button.BackgroundProperty);
            btnDashboard.ClearValue(System.Windows.Controls.Button.ForegroundProperty);

            btn_FTPServer.ClearValue(System.Windows.Controls.Button.BackgroundProperty);
            btn_FTPServer.ClearValue(System.Windows.Controls.Button.ForegroundProperty);

            btnSettings.ClearValue(System.Windows.Controls.Button.BackgroundProperty);
            btnSettings.ClearValue(System.Windows.Controls.Button.ForegroundProperty);

            btnLocal.ClearValue(System.Windows.Controls.Button.BackgroundProperty);
            btnLocal.ClearValue(System.Windows.Controls.Button.ForegroundProperty);

            PagesNavigation.Navigate(new System.Uri("Pages/PasswordPage.xaml", UriKind.RelativeOrAbsolute));
        }
        public void UnlockButton()
        {
            btn_FTPServer.Visibility = Visibility.Visible;
            btnLocal.Visibility = Visibility.Visible;
            btnSettings.Visibility = Visibility.Visible;
        }
        public void Navigate(string path)
        {
            PagesNavigation.Navigate(new System.Uri(path, UriKind.RelativeOrAbsolute));
        }
    }
}
