using OnlineMarketSystem.Data;
using OnlineMarketSystem.Models;
using OnlineMarketSystem.Services;
using OnlineMarketSystem.Views;
using System.Windows;
using System.Windows.Input;

namespace OnlineMarketSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private readonly CustomersService _customersService;
        //private readonly OnlineMarketDbContext _context;
        public MainWindow()
        {
            //_customersService = new();
            //_context = new();

            InitializeComponent();

            //CreateCustomer();
            //CreateOrder();
        }

        private void SignUp_Click(object sender, MouseButtonEventArgs e)
        {
            LeftGrid.Content = new SignUp();
        }

        private void Sign_Click(object sender, RoutedEventArgs e)
        {
            var signIn = new MarketMainWindow();
            signIn.Show();
            GetWindow(this).Close();
        }

        private void CreateCustomer()
        {
            var customer = new Customer()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "JohnDoe@gmail.com",
                Password = "*********",
                Phone = "+1(598)5557856",
                CreatedAt = DateTime.Now,
                ModifiedAt = null
            };

            //_customersService.Create(customer);
        }

        private void CreateOrder()
        {
            var order = new Order()
            {
                CustomerId = 1,
                TotalPrice = 60,
                OrderDate = DateTime.Now
            };

            //_context.Orders.Add(order);

            var orderDetails = new OrderDetail()
            {
                OrderId = order.Id,
                ProductId = 4,
                Quantity = 4,
                UnitPrice = 15,
            };

            //_context.OrderDetails.Add(orderDetails);
        }
    }
}