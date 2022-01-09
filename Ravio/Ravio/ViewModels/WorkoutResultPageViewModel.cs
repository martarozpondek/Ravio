using Ravio.Entities;
using Ravio.Services;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Ravio.ViewModels
{
    [QueryProperty(nameof(WorkoutResultId), "id")]
    public class WorkoutResultPageViewModel : BaseViewModel
    {
        public WorkoutResultPageViewModel()
        {
            GoToHomePageCommand = new Command(GoToHomePage);
        }

        private WorkoutsResultsService WorkoutsResultsService => DependencyService.Get<WorkoutsResultsService>();

        private int workoutResultid;
        public int WorkoutResultId
        {
            get { return workoutResultid; }
            set { SetProperty(ref workoutResultid, value); }
        }

        private WorkoutResultEntity workoutResult;
        public WorkoutResultEntity WorkoutResult
        {
            get { return workoutResult; }
            set { SetProperty(ref workoutResult, value); }
        }

        public async Task GetWorkoutResult()
        {
            WorkoutResult = await WorkoutsResultsService.GetById(WorkoutResultId);
        }

        public Command GoToHomePageCommand { get; set; }
        private async void GoToHomePage()
        {
            await Shell.Current.GoToAsync("///HomePage");
        }
    }
}
