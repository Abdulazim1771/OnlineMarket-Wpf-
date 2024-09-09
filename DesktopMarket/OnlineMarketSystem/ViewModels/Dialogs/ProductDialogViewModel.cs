using MvvmHelpers.Commands;
using OnlineMarketSystem.Models;
using OnlineMarketSystem.Services;
using System.Windows.Input;

namespace OnlineMarketSystem.ViewModels.Dialogs;

public class ProductDialogViewModel 
{
    private readonly CategoriesService _categoriesService;
    //private readonly ProductsService _productsService;
    //private readonly InventoriesService _inventoriesService;

    //public string ProductName { get; set; }
    //public string Description { get; set; }
    //public string SKU { get; set; }
    //public decimal Price { get; set; }
    //public int CategoryId { get; set; }
    //public int Quantity { get; set; }
    //public DateTime CreatedAt { get; set; }

    public List<Category> Categories { get; }

    public ICommand SaveCommand { get; }
    public ProductDialogViewModel()
    {
        Categories = [];

        SaveCommand = new Command(OnSave);

        _categoriesService = new();
        //_productsService = new();
        //_inventoriesService = new();

        Load();
    }

    private void Load()
    {
        var categories = _categoriesService.GetCategories();

        foreach (var category in categories)
        {
            Categories.Add(category);
        }
    }

    private void OnSave()
    {
        
    }
}

//if (decimal.TryParse(inputProductPrice.Text, out decimal price))
//{
//    MessageBox.Show(
//        "Please enter a valid price.", "Error",
//        MessageBoxButton.OK, MessageBoxImage.Error);
//    return;
//}

//if (int.TryParse(inputProductQuantity.Text, out int quantity))
//{
//    MessageBox.Show(
//        "Please enter a valid quantity.", "Error",
//        MessageBoxButton.OK, MessageBoxImage.Error);
//    return;
//}

//if (string.IsNullOrEmpty(inputProductName.Text) ||
//    string.IsNullOrEmpty(inputProductSKU.Text) ||
//    string.IsNullOrEmpty(inputProductPrice.Text) ||
//    string.IsNullOrEmpty(inputProductQuantity.Text))
//{
//    MessageBox.Show(
//        "You must fill all information correctly", "Error",
//        MessageBoxButton.OK, MessageBoxImage.Error);
//    return;
//}

//var product = new Product()
//{
//    Name = inputProductName.Text,
//    Description = inputProductDescription.Text,
//    SKU = inputProductSKU.Text,
//    Price = price,
//    CategoryId = (int)categoryCombobox.SelectedValue,

//};

//var inventory = new Inventory()
//{
//    Quantity = quantity,
//    ProductId = product.Id,
//    CreatedAt = DateTime.Now,
//};

//_productsService.Create(product);
//_inventoriesService.Create(inventory);
