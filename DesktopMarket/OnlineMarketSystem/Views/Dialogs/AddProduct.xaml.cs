using OnlineMarketSystem.Models;
using OnlineMarketSystem.Services;
using OnlineMarketSystem.ViewModels.Dialogs;
using System.Windows;

namespace OnlineMarketSystem.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        private readonly ProductsService _productsService;
        private readonly InventoriesService _inventoriesService;

        public AddProduct()
        {
            InitializeComponent();

            _productsService = new ProductsService();
            _inventoriesService = new InventoriesService();

            DataContext = new ProductDialogViewModel();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(inputProductName.Text) ||
                string.IsNullOrEmpty(inputProductSKU.Text) ||
                string.IsNullOrEmpty(inputProductPrice.Text) ||
                string.IsNullOrEmpty(inputProductQuantity.Text))
            {
                MessageBox.Show(
                    "You must fill all information correctly", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!decimal.TryParse(inputProductPrice.Text, out decimal price))
            {
                MessageBox.Show(
                    "Please enter a valid price.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(inputProductQuantity.Text, out int quantity))
            {
                MessageBox.Show(
                    "Please enter a valid quantity.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var product = new Product()
            {
                Name = inputProductName.Text,
                Description = inputProductDescription.Text,
                SKU = inputProductSKU.Text,
                Price = price,
                CategoryId = (int)categoryCombobox.SelectedValue,
                CreatedAt = DateTime.Now
            };

            _productsService.Create(product);

            var inventory = new Inventory()
            {
                Quantity = quantity,
                ProductId = product.Id,
                CreatedAt = DateTime.Now,
            };

            _inventoriesService.Create(inventory);

            MessageBox.Show(
            $"Product: {product.Name} {product.SKU} successfully added.",
            "Success",
            MessageBoxButton.OK,
            MessageBoxImage.Information);

            Close();
        }
    }
}
