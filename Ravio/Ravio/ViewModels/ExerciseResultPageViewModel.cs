using Ravio.Entities;
using Ravio.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    [QueryProperty(nameof(ExerciseResultId), "id")]
    public class ExerciseResultPageViewModel : BaseViewModel
    {
        public ExerciseResultPageViewModel()
        {
            GoToHomePageCommand = new Command(GoToHomePage);
        }

        private ExercisesResultsService ExercisesResultsService => DependencyService.Get<ExercisesResultsService>();

        private int exerciseResultid;
        public int ExerciseResultId
        {
            get { return exerciseResultid; }
            set { SetProperty(ref exerciseResultid, value); GetExerciseResult(); }
        }

        private ExerciseResultEntity exerciseResult;
        public ExerciseResultEntity ExerciseResult
        {
            get { return exerciseResult; }
            set { SetProperty(ref exerciseResult, value); }
        }

        public async Task GetExerciseResult()
        {
            ExerciseResult = await ExercisesResultsService.GetById(ExerciseResultId);
        }

        public Command GoToHomePageCommand { get; set; }
        private async void GoToHomePage()
        {
            await Shell.Current.GoToAsync("///HomePage");
        }
    }
}
