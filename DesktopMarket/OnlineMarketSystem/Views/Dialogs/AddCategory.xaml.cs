using OnlineMarketSystem.ViewModels;
using System.Windows;

namespace OnlineMarketSystem.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for AddCategory.xaml
    /// </summary>
    public partial class AddCategory : Window
    {
        public AddCategory()
        {
            InitializeComponent();

            DataContext = new CategoryDialogViewModel();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
