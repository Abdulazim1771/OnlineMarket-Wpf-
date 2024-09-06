using MvvmHelpers;
using MvvmHelpers.Commands;
using OnlineMarketSystem.Models;
using OnlineMarketSystem.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace OnlineMarketSystem.ViewModels;

public class CategoriesViewModel : BaseViewModel
{
    private readonly CategoriesService _categoriesService;
    private string _searchText;

    public string SearchText
    {
        get => _searchText;
        set
        {
            SetProperty(ref _searchText, value);
            SearchCategories(value);

        }
    }

    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; }

    public ObservableCollection<Category> Categories { get; }

    public CategoriesViewModel()
    {
        _categoriesService = new();
        Categories = [];

        EditCommand = new Command<Category>(OnEdit);
        DeleteCommand = new Command<Category>(OnDelete);

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

    private void SearchCategories(string searchText)
    {
        var categories = _categoriesService.GetCategories(searchText);

        Categories.Clear();

        foreach (var category in categories)
        {
            Categories.Add(category);
        }
    }

    private void OnEdit(Category category)
    {

    }

    private void OnDelete(Category category)
    {
        var result = MessageBox.Show(
            $"Are you sure you want to delete: {category.Name}?",
            "Confirm your action.",
            MessageBoxButton.YesNo,
            MessageBoxImage.Warning);

        if (result == MessageBoxResult.No)
        {
            return;
        }

        _categoriesService.Delete(category);
        MessageBox.Show(
            $"Category: {category.Name} successfully deleted.",
            "Success",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
    }
}
