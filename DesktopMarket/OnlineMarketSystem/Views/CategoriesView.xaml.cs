using OnlineMarketSystem.ViewModels;
using OnlineMarketSystem.Views.Dialogs;
using System.Windows;
using System.Windows.Controls;

namespace OnlineMarketSystem.Views
{
    /// <summary>
    /// Interaction logic for CategoriesView.xaml
    /// </summary>
    public partial class CategoriesView : UserControl
    {
        public CategoriesView()
        {
            InitializeComponent();

            DataContext = new CategoriesViewModel();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddCategory();
            window.Show();
        }
    }
}
