using Xamarin.Forms;

namespace Ravio.Views
{
    public partial class ExercisePage : ContentPage
    {
        public ExercisePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var ViewModel = BindingContext as ViewModels.ExercisePageViewModel;
            await ViewModel.GetExercise();
        }
    }
}