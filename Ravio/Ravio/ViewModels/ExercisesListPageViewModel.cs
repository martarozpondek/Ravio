using Ravio.Entities;
using Ravio.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    public class ExercisesListPageViewModel : BaseViewModel
    {
        public ExercisesListPageViewModel()
        {
            StartExerciseCommand = new Command<string>(StartExercise);

            GetExercises();
        }

        private ExercisesRepository ExercisesRepository => DependencyService.Get<ExercisesRepository>();

        public async Task GetExercises()
        {
            Exercises = await ExercisesRepository.GetAll();
        }

        private List<ExerciseEntity> exercises;
        public List<ExerciseEntity> Exercises
        {
            get { return exercises; }
            set { SetProperty(ref exercises, value); }
        }

        public Command<string> StartExerciseCommand { get; set; }
        private async void StartExercise(string exerciseName)
        {
            await Shell.Current.GoToAsync($"ExercisePage?exerciseName={exerciseName}");
        }
    }
}
