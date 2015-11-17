using Anchor_Final.ViewModels;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;
using Bar = Anchor_Final.Views.MainPage;

namespace Anchor_Final.Views
{
    public sealed partial class DetailPage : Page
    {
        public DetailPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
        }

        // strongly-typed view models enable x:bind
        public DetailPageViewModel ViewModel => DataContext as DetailPageViewModel;

        private void button_back_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            browserPreview.GoBack();
        }

        private void button_forward_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            browserPreview.GoForward();
        }

        private void button_home_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            
        }
    }
}

