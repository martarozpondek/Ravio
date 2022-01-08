using Xamarin.Forms;

namespace Ravio.Views
{
    public partial class FoodListPage : ContentPage
    {
        public FoodListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var ViewModel = BindingContext as ViewModels.FoodListPageViewModel;
            await ViewModel.GetFoodResult();
        }
    }
}