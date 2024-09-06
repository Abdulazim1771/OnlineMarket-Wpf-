using OnlineMarketSystem.Models;
using OnlineMarketSystem.Services;
using OnlineMarketSystem.ViewModels;
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
        public CustomersView()
        {
            InitializeComponent();

            DataContext = new CustomersViewModel();
        }
    }
}
