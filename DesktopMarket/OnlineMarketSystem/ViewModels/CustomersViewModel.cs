using MvvmHelpers;
using OnlineMarketSystem.Models;
using OnlineMarketSystem.Services;
using System.Collections.ObjectModel;

namespace OnlineMarketSystem.ViewModels;

public class CustomersViewModel : BaseViewModel
{
    private readonly CustomersService _customersService;
    private string _searchText;

    public string SearchText
    {
        get => _searchText;
        set
        {
            SetProperty(ref _searchText, value);
            SearchCustomers(value);

        }
    }

    public ObservableCollection<Customer> Customers { get; }

    public CustomersViewModel()
    {
        _customersService = new();
        Customers = [];

        Load();
    }

    private void Load()
    {
        var customers = _customersService.GetCustomers();

        foreach (var customer in customers)
        {
            Customers.Add(customer);
        }
    }

    private void SearchCustomers(string searchText)
    {
        var customers = _customersService.GetCustomers(searchText);

        Customers.Clear();

        foreach (var customer in customers)
        {
            Customers.Add(customer);
        }
    }
}
