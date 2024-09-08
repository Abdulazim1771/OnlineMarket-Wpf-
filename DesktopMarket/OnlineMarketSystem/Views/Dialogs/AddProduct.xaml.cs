using OnlineMarketSystem.ViewModels.Dialogs;
using System.Windows;

namespace OnlineMarketSystem.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public AddProduct()
        {
            InitializeComponent();

            DataContext = new ProductDialogViewModel();
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
