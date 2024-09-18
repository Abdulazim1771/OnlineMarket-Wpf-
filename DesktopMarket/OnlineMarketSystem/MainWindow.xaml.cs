using OnlineMarketSystem.Data;
using OnlineMarketSystem.Models;
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
        public MainWindow()
        {
            InitializeComponent();
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

        private void CreateOrder()
        {
            var order = new Order()
            {
                CustomerId = 1,
                TotalPrice = 60,
                OrderDate = DateTime.Now,
            };


            //_context.Orders.Add(order);
            //_context.SaveChanges();

            var orderDetails = new OrderDetail()
            {
                OrderId = order.Id,
                ProductId = 4,
                Quantity = 4,
                UnitPrice = 15,
            };

            //_context.OrderDetails.Add(orderDetails);
            //_context.SaveChanges();
        }
    }
}