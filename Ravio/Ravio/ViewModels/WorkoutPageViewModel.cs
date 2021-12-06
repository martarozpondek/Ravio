using Ravio.Entities;
using Ravio.Services;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Ravio.ViewModels
{
    [QueryProperty(nameof(WorkoutName), "workoutName")]
    public class WorkoutPageViewModel : BaseViewModel
    {
        public WorkoutPageViewModel()
        {
            Map = new Xamarin.Forms.Maps.Map();

            FinishWorkoutCommand = new Command(FinishWorkout);
        }

        private WorkoutService WorkoutService => DependencyService.Get<WorkoutService>();
        private WorkoutsResultsService WorkoutsResultsService => DependencyService.Get<WorkoutsResultsService>();

        private string workoutName;
        public string WorkoutName
        {
            get { return workoutName; }
            set { SetProperty(ref workoutName, value); }
        }

        private Xamarin.Forms.Maps.Map map;
        public Xamarin.Forms.Maps.Map Map
        {
            get { return map; }
            set { SetProperty(ref map, value); }
        }

        private WorkoutResultEntity workoutResult;
        public WorkoutResultEntity WorkoutResult
        {
            get { return workoutResult; }
            set { SetProperty(ref workoutResult, value); }
        }

        private async Task StartWorkout()
        {
            Polyline Line = new Polyline() { StrokeColor = Color.Purple, StrokeWidth = 10 };

            while (IsWorkoutMode)
            {
                var position = await WorkoutService.GetUserPosition();

                WorkoutResult.Coordinates.Add(new CoordinatesEntity(position.Latitude, position.Latitude));

                Map.MoveToRegion(new MapSpan(position, 0.01, 0.01));

                Line.Geopath.Add(position);
                Map.MapElements.Add(Line);

                Map.MapElements.Remove(Line);

                await Task.Delay(1000);
            }
        }

        private bool IsWorkoutMode { get; set; } = false;

        public Command FinishWorkoutCommand { get; set; }
        private async void FinishWorkout()
        {
            var result = await WorkoutService.FinishWorkout(workoutResult);

            IsWorkoutMode = false;

            await Shell.Current.GoToAsync($"WorkoutResultPage?{result.Id}");
        }
    }
}
