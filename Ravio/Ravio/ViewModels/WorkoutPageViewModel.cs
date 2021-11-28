using Xamarin.Forms;

namespace Ravio.ViewModels
{
    public class WorkoutPageViewModel : BaseViewModel
    {
        public WorkoutPageViewModel()
        {
            FinishWorkoutCommand = new Command(FinishWorkout);
        }

        public Command FinishWorkoutCommand { get; set; }
        private async void FinishWorkout()
        {
            await Shell.Current.GoToAsync("WorkoutResultPage");
        }
    }
}
