using Ravio.Entities;
using Ravio.Repositories;
using Ravio.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    [QueryProperty(nameof(ExerciseName), "exerciseName")]
    public class ExercisePageViewModel : BaseViewModel
    {
        public ExercisePageViewModel()
        {
            BeginExerciseCommand = new Command(BeginExercise);
            FinishExerciseCommand = new Command(FinishExercise);

            ExerciseResult = new ExerciseResultEntity();
        }

        private ExercisesResultsService ExercisesResultsService => DependencyService.Get<ExercisesResultsService>();
        private ExerciseService ExerciseService => DependencyService.Get<ExerciseService>();
        private ExercisesRepository ExercisesRepository => DependencyService.Get<ExercisesRepository>();

        public async Task GetExercise()
        {
            Exercise = await ExercisesRepository.GetByName(ExerciseName);
        }

        private async Task StartExercise()
        {
            GetExercise();

            IsExerciseMode = true;

            ExerciseResult.StartTime = DateTime.Now;

            await TextToSpeech.SpeakAsync($"Rozpocznij {Exercise.Name}");

            while (IsExerciseMode)
            {
                Timer += TimeSpan.FromSeconds(1);
                await Task.Delay(1000);
            }
        }

        private bool isExerciseMode;
        public bool IsExerciseMode
        {
            get { return isExerciseMode; }
            set { SetProperty(ref isExerciseMode, value); }
        }

        private string exerciseName;
        public string ExerciseName
        {
            get { return exerciseName; }
            set { SetProperty(ref exerciseName, value); }
        }

        private ExerciseEntity exercise;
        public ExerciseEntity Exercise
        {
            get { return exercise; }
            set { SetProperty(ref exercise, value); }
        }

        private ExerciseResultEntity exerciseResult;
        public ExerciseResultEntity ExerciseResult
        {
            get { return exerciseResult; }
            set { SetProperty(ref exerciseResult, value); }
        }

        private TimeSpan timer;
        public TimeSpan Timer
        {
            get { return timer; }
            set { SetProperty(ref timer, value); }
        }

        public Command BeginExerciseCommand { get; set; }
        private async void BeginExercise()
        {
            await StartExercise();
        }

        public Command FinishExerciseCommand { get; set; }
        private async void FinishExercise()
        {
            IsExerciseMode = false;

            ExerciseResult.EndTime = DateTime.Now;

            ExerciseResult.NumberOfRepetitions = Convert.ToInt32(await Shell.Current.DisplayPromptAsync("Liczba powtórzeń", "Wpisz liczbę powtórzeń"));

            var result = await ExerciseService.FinishExercise(ExerciseResult);

            await Shell.Current.GoToAsync($"ExerciseResultPage?{result.Id}");
        }
    }
}
