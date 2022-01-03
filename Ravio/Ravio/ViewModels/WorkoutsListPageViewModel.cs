using Ravio.Entities;
using Ravio.Repositories;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    public class WorkoutsListPageViewModel : BaseViewModel
    {
        public WorkoutsListPageViewModel()
        {
            StartWorkoutCommand = new Command<string>(StartWorkout);

            GetWorkouts();
        }

        private WorkoutsRepository WorkoutsRepository => DependencyService.Get<WorkoutsRepository>();

        private List<WorkoutEntity> workouts;
        public List<WorkoutEntity> Workouts
        {
            get { return workouts; }
            set { SetProperty(ref workouts, value); }
        }

        public async Task GetWorkouts()
        {
            Workouts = await WorkoutsRepository.GetAll();
        }

        public Command<string> StartWorkoutCommand { get; set; }
        private async void StartWorkout(string workoutName)
        {
            await Shell.Current.GoToAsync($"WorkoutPage?workoutName={workoutName}");
        }
    }
}
