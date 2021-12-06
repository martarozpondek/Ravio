using Ravio.Entities;
using Ravio.Repositories;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    public class ExercisesListPageViewModel : BaseViewModel
    {
        public ExercisesListPageViewModel()
        {
            Exercises = new List<ExerciseEntity>();
            Exercises.Add(new ExerciseEntity() { Name = "Przysiady " });
            Exercises.Add(new ExerciseEntity() { Name = "Brzuszki" });
            Exercises.Add(new ExerciseEntity() { Name = "Pompki " });

            StartExerciseCommand = new Command<string>(StartExercise);
        }

        private ExercisesRepository ExercisesRepository => DependencyService.Get<ExercisesRepository>();

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
