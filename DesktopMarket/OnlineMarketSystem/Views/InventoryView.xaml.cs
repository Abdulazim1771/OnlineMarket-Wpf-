using OnlineMarketSystem.Models;
using OnlineMarketSystem.Services;
using OnlineMarketSystem.ViewModels;
using OnlineMarketSystem.Views.Dialogs;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace OnlineMarketSystem.Views
{
    /// <summary>
    /// Interaction logic for InventoryView.xaml
    /// </summary>
    public partial class InventoryView : UserControl
    {
        public InventoryView()
        {
            InitializeComponent();

            DataContext = new InventoriesViewModel();
        }

        //private void Add_Click(object sender, RoutedEventArgs e)
        //{
        //    var window = new AddInventory();
        //    window.Show();
        //}
    }
}
