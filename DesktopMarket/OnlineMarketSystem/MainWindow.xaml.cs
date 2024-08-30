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
    }
}