using Xamarin.Forms;

namespace Ravio.Views
{
    public partial class ExercisesStatisticsPage : ContentPage
    {
        public ExercisesStatisticsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var ViewModel = BindingContext as ViewModels.ExercisesStatisticsPageViewModel;
            await ViewModel.GetExerciseResults();
            await ViewModel.GetExerciseAwards();
        }
    }
}