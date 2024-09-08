using OnlineMarketSystem.Models;
using OnlineMarketSystem.Services;
using OnlineMarketSystem.ViewModels.Extensions;
using System.ComponentModel;
using System.Windows.Input;

namespace OnlineMarketSystem.ViewModels.Dialogs;

public class ProductDialogViewModel : INotifyPropertyChanged
{
    private readonly ProductsService _productsService;
    private readonly CategoriesService _categoriesService;

    private string _productName;
    public string ProductName
    {
        get => _productName;
        set
        {
            if (_productName != value)
            {
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }
    }

    private string _description;
    public string Description
    {
        get => _description;
        set
        {
            if (_description != value)
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
    }

    private string _SKU;
    public string SKU
    {
        get => _SKU;
        set
        {
            if (_SKU != value)
            {
                _SKU = value;
                OnPropertyChanged(nameof(SKU));
            }
        }
    }

    private decimal _price;
    public decimal Price 
    { 
        get => _price;
        set
        {
            if (_price != value)
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        } 
    }

    private Category _selectedCategory;
    public Category SelectedCategory 
    { 
        get => _selectedCategory; 
        set
        {
            if(_selectedCategory != value)
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        } 
    }

    private int _numberOfProducts;
    public int NumberOfProducts 
    { 
        get => _numberOfProducts; 
        set
        {
            if (_numberOfProducts != value)
            {
                _numberOfProducts = value;
                OnPropertyChanged(nameof(NumberOfProducts));
            }
        }
    }

    public List<Category> Categories { get; }

    public ICommand SaveCommand { get; }
    public ProductDialogViewModel()
    {
        Categories = [];

        SaveCommand = new RelayCommand(OnSave);

        _productsService = new();
        _categoriesService = new();

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
        var product = new Product()
        {
            Name = ProductName,
            Description = Description,
            SKU = SKU,
            Price = Price,
            CategoryId = SelectedCategory?.Id ?? 0,  // Handling null category
            Inventory = new Inventory { Quantity = NumberOfProducts }
        };

        _productsService.Create(product);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
