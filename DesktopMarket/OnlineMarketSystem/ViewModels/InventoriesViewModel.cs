using MvvmHelpers;
using MvvmHelpers.Commands;
using OnlineMarketSystem.Models;
using OnlineMarketSystem.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace OnlineMarketSystem.ViewModels;

public class InventoriesViewModel : BaseViewModel
{
    private readonly InventoriesService _inventoriesService;
    private string _searchText;

    public string SearchText
    {
        get => _searchText;
        set
        {
            SetProperty(ref _searchText, value);
            SearchInventories(value);

        }
    }

    public ICommand EditCommand { get; }

    public ObservableCollection<Inventory> Inventories { get; }

    public InventoriesViewModel()
    {
        _inventoriesService = new();
        Inventories = [];

        EditCommand = new Command<Inventory>(OnEdit);

        Load();
    }

    private void Load()
    {
        var inventories = _inventoriesService.GetInventories();

        foreach(var inventory in inventories)
        {
            Inventories.Add(inventory);
        }
    }

    private void SearchInventories(string searchText)
    {
        var inventories = _inventoriesService.GetInventories(searchText);

        Inventories.Clear();

        foreach(var inventory in inventories)
        {
            Inventories.Add(inventory);
        }
    }

    private void OnEdit(Inventory inventory)
    {

    }
}
