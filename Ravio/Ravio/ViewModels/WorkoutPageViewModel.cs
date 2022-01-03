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

            StartWorkout();
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

        public async Task GetWorkout()
        {
            Workout = await WorkoutsRepository.GetByName(WorkoutName);
            WorkoutResult.Workout = Workout;
        }

        private async Task StartWorkout()
        {
            IsWorkoutMode = true;

            WorkoutResult.StartTime = DateTime.Now;

            Polyline Line = new Polyline() { StrokeColor = Color.Purple, StrokeWidth = 10 };

            List<double> Speeds = new List<double>();

            var poosition = await WorkoutService.GetUserPosition();
            Map.MoveToRegion(new MapSpan(poosition, 0.01, 0.01));

            while (IsWorkoutMode)
            {
                Map.MapElements.Remove(Line);
                var position = await WorkoutService.GetUserPosition();
                Speeds.Add(await WorkoutService.GetUserSpeed());

                //WorkoutResult.Coordinates.Add(new CoordinatesEntity(position.Latitude, position.Latitude));

                Map.MoveToRegion(new MapSpan(position, 0.01, 0.01));

                Line.Geopath.Add(position);
                Map.MapElements.Add(Line);



                await Task.Delay(5000);
            }

            WorkoutResult.AverageSpeed = Speeds.Average();
        }

        private bool IsWorkoutMode { get; set; } = false;

        public Command FinishWorkoutCommand { get; set; }
        private async void FinishWorkout()
        {
            IsWorkoutMode = false;

            WorkoutResult.EndTime = DateTime.Now;

            WorkoutResult.Distance = WorkoutService.CalculateDistanceBetweenPoints(WorkoutResult.Coordinates);

            var result = await WorkoutService.FinishWorkout(workoutResult);

            await Shell.Current.GoToAsync($"WorkoutResultPage?{result.Id}");
        }
    }
}
