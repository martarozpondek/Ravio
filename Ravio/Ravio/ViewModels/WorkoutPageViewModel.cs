using Ravio.Entities;
using Ravio.Repositories;
using Ravio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

            WorkoutResult = new WorkoutResultEntity();

            FinishWorkoutCommand = new Command(FinishWorkout);
        }

        private WorkoutService WorkoutService => DependencyService.Get<WorkoutService>();
        private WorkoutsResultsService WorkoutsResultsService => DependencyService.Get<WorkoutsResultsService>();
        private WorkoutsRepository WorkoutsRepository => DependencyService.Get<WorkoutsRepository>();

        private WorkoutEntity workout;
        public WorkoutEntity Workout
        {
            get { return workout; }
            set { SetProperty(ref workout, value); }
        }
        
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

        private List<Position> positions { get; set; } = new List<Position>();
        private List<double> speeds { get; set; } = new List<double>();

        public async Task GetWorkout()
        {
            Workout = await WorkoutsRepository.GetByName(WorkoutName);
            WorkoutResult.WorkoutId = Workout.Id;
        }

        public async Task StartWorkout()
        {
            IsWorkoutMode = true;

            WorkoutResult.StartTime = DateTime.Now;

            Polyline Line = new Polyline() { StrokeColor = Color.Purple, StrokeWidth = 10 };

            while (IsWorkoutMode)
            {
                var position = await WorkoutService.GetUserPosition();
                positions.Add(position);
                speeds.Add(await WorkoutService.GetUserSpeed());

                Map.MoveToRegion(new MapSpan(position, 0.01, 0.01));

                Line.Geopath.Add(position);
                Map.MapElements.Add(Line);

                await Task.Delay(5000);

                Map.MapElements.Remove(Line);
            }

        }

        private bool IsWorkoutMode { get; set; } = false;

        public Command FinishWorkoutCommand { get; set; }
        private async void FinishWorkout()
        {
            IsWorkoutMode = false;

            WorkoutResult.Distance = WorkoutService.CalculateDistanceBetweenPoints(positions);

            WorkoutResult.AverageSpeed = speeds.Average();

            WorkoutResult.WorkoutId = Workout.Id;

            WorkoutResult.EndTime = DateTime.Now;

            var result = await WorkoutService.FinishWorkout(workoutResult);

            await Shell.Current.GoToAsync($"WorkoutResultPage?id={result.Id}");
        }
    }
}
