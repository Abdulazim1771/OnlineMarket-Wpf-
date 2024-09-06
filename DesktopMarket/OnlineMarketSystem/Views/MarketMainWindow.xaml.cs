using System.Windows;
using System.Windows.Input;

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

        private void Inventory_Click(object sender, RoutedEventArgs e)
        {
            MainUserControl.Content = new InventoryView();
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
