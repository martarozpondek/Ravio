using Xamarin.Forms;

namespace Ravio.Views
{
    public partial class ExerciseResultPage : ContentPage
    {
        public ExerciseResultPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var ViewModel = BindingContext as ViewModels.ExerciseResultPageViewModel;
            await ViewModel.GetExerciseResult();
        }
    }
}