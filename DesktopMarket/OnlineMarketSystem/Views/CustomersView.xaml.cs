using OnlineMarketSystem.Models;
using OnlineMarketSystem.Services;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Windows.Controls;

namespace OnlineMarketSystem.Views
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {
        private readonly CustomersService _customersService;
        public ObservableCollection<Customer> Customers;

        public CustomersView()
        {
            InitializeComponent();

            _customersService = new CustomersService();
            Customers = new ObservableCollection<Customer>();

            Load();
            CustomersDataGrid.ItemsSource = Customers;
        }

        private void Load()
        {
            var customers = _customersService.GetCustomers();
            Customers.Clear();
            foreach (var customer in customers)
            {
                Customers.Add(customer);
            }
        }
    }
}
