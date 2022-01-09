using Xamarin.Forms;

namespace Ravio.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var ViewModel = BindingContext as ViewModels.HomePageViewModel;
            await ViewModel.GetFoodResult();
        }
    }
}