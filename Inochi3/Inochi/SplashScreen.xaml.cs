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
using System.Windows.Threading;
using UIKitTutorials;

namespace Inochi
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        readonly DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public SplashScreen()
        {
            InitializeComponent();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 12);
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();

            dispatcherTimer.Stop();
            this.Close();
        }

        private void store_Completed(object sender, EventArgs e)
        {
              MyPath.Fill = new SolidColorBrush(Colors.Black);
        }
    }
}
