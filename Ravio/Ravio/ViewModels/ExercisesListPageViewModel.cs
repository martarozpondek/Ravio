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
            Exercises.Add(new ExerciseEntity() { Name = "Siema " });
            Exercises.Add(new ExerciseEntity() { Name = "Elo " });
            Exercises.Add(new ExerciseEntity() { Name = "Siemsasaa " });
        }

        private ExercisesRepository ExercisesRepository => DependencyService.Get<ExercisesRepository>();

        private List<ExerciseEntity> exercises;
        public List<ExerciseEntity> Exercises
        {
            get { return exercises; }
            set { SetProperty(ref exercises, value); }
        }
    }
}
