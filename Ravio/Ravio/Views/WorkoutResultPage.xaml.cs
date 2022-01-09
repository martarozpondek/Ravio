using Xamarin.Forms;

namespace Ravio.Views
{
    public partial class WorkoutResultPage : ContentPage
    {
        public WorkoutResultPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var ViewModel = BindingContext as ViewModels.WorkoutResultPageViewModel;
            await ViewModel.GetWorkoutResult();
        }
    }
}