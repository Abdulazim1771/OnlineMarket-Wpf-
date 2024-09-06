using MvvmHelpers;
using MvvmHelpers.Commands;
using OnlineMarketSystem.Models;
using OnlineMarketSystem.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace OnlineMarketSystem.ViewModels;

public class ProductsViewModel : BaseViewModel
{
    private readonly ProductsService _productsService;
	private string _searchText;

	public string SearchText
	{
		get => _searchText; 
		set
		{
			SetProperty(ref _searchText, value);
            SearchProducts(value);

        }
	}

    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; }

    public ObservableCollection<Product> Products { get; }

	public ProductsViewModel()
	{
		_productsService = new();

        EditCommand = new Command<Product>(OnEdit);
        DeleteCommand = new Command<Product>(OnDelete);
    }

	private void SearchProducts(string searchText)
	{
		var products = _productsService.GetProducts(searchText);

		Products.Clear();

        foreach (var product in products)
        {
			Products.Add(product);
        }
    }

    private void OnEdit(Product product)
    {

    }

    private void OnDelete(Product product)
    {
        var result = MessageBox.Show(
            $"Are you sure you want to delete: {product.Name} {product.SKU}?",
            "Confirm your action.",
            MessageBoxButton.YesNo,
            MessageBoxImage.Warning);   

        if (result == MessageBoxResult.No)
        {
            return;
        }

        _productsService.Delete(product);
            MessageBox.Show(
            $"Patient: {product.Name} {product.SKU} successfully deleted.",
            "Success",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
    }
}

