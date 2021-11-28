using Ravio.Entities;
using Ravio.Repositories;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    public class WorkoutsListPageViewModel : BaseViewModel
    {
        public WorkoutsListPageViewModel()
        {
            GoToWorkoutPageCommand = new Command(async () => { await Shell.Current.GoToAsync("WorkoutPage"); });

            Workouts = new List<WorkoutEntity>() { new WorkoutEntity() { Name = "Bieganie" }, new WorkoutEntity() { Name = "Rower" } };
        }

        private WorkoutsRepository WorkoutsRepository => DependencyService.Get<WorkoutsRepository>();

        private List<WorkoutEntity> workouts;
        public List<WorkoutEntity> Workouts
        {
            get { return workouts; }
            set { SetProperty(ref workouts, value); }
        }

        public Command GoToWorkoutPageCommand { get; set; }
    }
}
