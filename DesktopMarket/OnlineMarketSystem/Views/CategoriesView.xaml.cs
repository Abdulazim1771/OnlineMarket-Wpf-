using OnlineMarketSystem.Models;
using OnlineMarketSystem.Services;
using OnlineMarketSystem.Views.Dialogs;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace OnlineMarketSystem.Views
{
    /// <summary>
    /// Interaction logic for CategoriesView.xaml
    /// </summary>
    public partial class CategoriesView : UserControl
    {
        private readonly CategoriesService _categoriesService;
        public ObservableCollection<Category> Categories;

        public CategoriesView()
        {
            InitializeComponent();

            _categoriesService = new CategoriesService();
            Categories = new ObservableCollection<Category>();

            Load();
            CategoriesDataGrid.ItemsSource = Categories;
        }

        void Load()
        {
            var categories = _categoriesService.GetCategories();
            Categories.Clear();
            foreach (var category in categories)
            {
                Categories.Add(category);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddCategory();
            window.Show();
        }
    }
}
