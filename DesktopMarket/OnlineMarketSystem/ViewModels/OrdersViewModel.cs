using MvvmHelpers;
using MvvmHelpers.Commands;
using OnlineMarketSystem.Models;
using OnlineMarketSystem.Services;
using System.Collections.ObjectModel;

namespace OnlineMarketSystem.ViewModels;

public class OrdersViewModel : BaseViewModel
{
    private readonly OrdersService _ordersService;
    private string _searchText;

    public string SearchText
    {
        get => _searchText;
        set
        {
            SetProperty(ref _searchText, value);
            SearchOrders(value);

        }
    }

    public ObservableCollection<Order> Orders { get; }

    public OrdersViewModel()
    {
        _ordersService = new();
        Orders = [];

        Load();
    }

    private void Load()
    {
        var orders = _ordersService.GetOrders();

        foreach(var order in orders)
        {
            Orders.Add(order);
        }
    }

    private void SearchOrders(string searchText)
    {
        var orders = _ordersService.GetOrders(searchText);

        Orders.Clear();

        foreach (var order in orders)
        {
            Orders.Add(order);
        }
    }
}
