using MvvmHelpers.Commands;
using OnlineMarketSystem.Models;
using OnlineMarketSystem.Services;
using System.Windows.Input;

namespace OnlineMarketSystem.ViewModels.Dialogs;

public class ProductDialogViewModel
{
    private readonly ProductsService _productsService;
    private readonly CategoriesService _categoriesService;

    public List<Category> Categories { get; }

    public ICommand SaveCommand { get; }
    public ProductDialogViewModel()
    {
        Categories = [];

        SaveCommand = new Command(OnSave);

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

        };

        _productsService.Create(product);
    }
}
