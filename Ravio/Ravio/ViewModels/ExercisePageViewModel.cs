using Ravio.Entities;
using Ravio.Repositories;
using Ravio.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    [QueryProperty(nameof(ExerciseName), "exerciseName")]
    public class ExercisePageViewModel : BaseViewModel
    {
        public ExercisePageViewModel()
        {
            GetExercise();

            FinishExerciseCommand = new Command(FinishExercise);
        }

        private ExercisesResultsService ExercisesResultsService => DependencyService.Get<ExercisesResultsService>();
        private ExerciseService ExerciseService => DependencyService.Get<ExerciseService>();
        private ExercisesRepository ExercisesRepository => DependencyService.Get<ExercisesRepository>();

        public async Task GetExercise()
        {
            ExerciseEntity = await ExercisesRepository.GetByName(ExerciseName);
        }

        private async Task StartExercise()
        {

        }

        private bool IsExerciseMode { get; set; } = false;

        private string exerciseName;
        public string ExerciseName
        {
            get { return exerciseName; }
            set { SetProperty(ref exerciseName, value); }
        }

        private ExerciseEntity exerciseEntity;
        public ExerciseEntity ExerciseEntity
        {
            get { return exerciseEntity; }
            set { SetProperty(ref exerciseEntity, value); }
        }

        private ExerciseResultEntity exerciseResult;
        public ExerciseResultEntity ExerciseResult
        {
            get { return exerciseResult; }
            set { SetProperty(ref exerciseResult, value); }
        }

        public Command FinishExerciseCommand { get; set; }
        private async void FinishExercise()
        {
            var result = await ExerciseService.FinishExercise(ExerciseResult);

            IsExerciseMode = false;

            await Shell.Current.GoToAsync($"ExerciseResultPage?{result.Id}");
        }
    }
}
