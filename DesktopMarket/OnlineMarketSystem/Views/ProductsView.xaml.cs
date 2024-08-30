using OnlineMarketSystem.Models;
using OnlineMarketSystem.Services;
using OnlineMarketSystem.Views.Dialogs;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace OnlineMarketSystem.Views
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class ProductsView : UserControl
    {
        private readonly ProductsService _productsService;
        public ObservableCollection<Product> Products;

        public ProductsView()
        {
            InitializeComponent();

            _productsService = new ProductsService();
            Products = new ObservableCollection<Product>();

            Load();
            ProductsDataGrid.ItemsSource = Products;
        }

        void Load()
        {
            var products = _productsService.GetProducts();
            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }

        private void Add_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var window = new AddProduct();
            window.Show();
        }
    }
}
