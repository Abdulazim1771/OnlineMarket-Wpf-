using OnlineMarketSystem.Models;
using OnlineMarketSystem.Services;
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
        private readonly InventoriesService _inventoriesService;
        public ObservableCollection<Inventory> Inventories;

        public InventoryView()
        {
            InitializeComponent();

            _inventoriesService = new InventoriesService();
            Inventories = new ObservableCollection<Inventory>();

            Load();
            InventoryDataGrid.ItemsSource = Inventories;
        }

        void Load()
        {
            var inventories = _inventoriesService.GetInventories();
            Inventories.Clear();

            foreach (var inventory in inventories)
            {
                Inventories.Add(inventory);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddInventory();
            window.Show();
        }
    }
}
