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

namespace OnlineMarketSystem.Views
{
    /// <summary>
    /// Interaction logic for MarketMainWindow.xaml
    /// </summary>
    public partial class MarketMainWindow : Window
    {
        public MarketMainWindow()
        {
            InitializeComponent();
            //Products_Click();
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            //Background = "#7b5cd6"
            //Foreground = "White"
            
            MainUserControl.Content = new ProductsView();
        }

        private void Categories_Click(object sender, RoutedEventArgs e)
        {
            MainUserControl.Content = new CategoriesView();
        }

        private void Customers_Click(object sender, RoutedEventArgs e)
        {
            MainUserControl.Content = new CustomersView();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            var logout = new MainWindow();
            logout.Show();
            GetWindow(this).Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private bool IsMaximized = false;

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximized = true;
                }
            }
        }
    }
}
