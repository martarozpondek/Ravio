using Xamarin.Forms;

namespace Ravio.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var ViewModel = BindingContext as ViewModels.ProfilePageViewModel;
            await ViewModel.GetUserByUserName();
            await ViewModel.GetLastBodyMessurementsByUserName();
        }
    }
}