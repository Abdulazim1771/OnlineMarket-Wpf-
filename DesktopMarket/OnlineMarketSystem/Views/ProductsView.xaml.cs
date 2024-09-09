using OnlineMarketSystem.ViewModels;
using OnlineMarketSystem.Views.Dialogs;
using System.Windows;
using System.Windows.Controls;

namespace OnlineMarketSystem.Views
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class ProductsView : UserControl
    {
        public ProductsView()
        {
            InitializeComponent();

            DataContext = new ProductsViewModel();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddProduct();
            window.Show();
        }
    }
}
