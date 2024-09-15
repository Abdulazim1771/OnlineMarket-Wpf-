using OnlineMarketSystem.Services;
using OnlineMarketSystem.ViewModels;
using System.Windows.Controls;

namespace OnlineMarketSystem.Views
{
    /// <summary>
    /// Interaction logic for OrdersView.xaml
    /// </summary>
    public partial class OrdersView : UserControl
    {
        public OrdersView()
        {
            InitializeComponent();

            DataContext = new OrdersViewModel();
        }
    }
}
