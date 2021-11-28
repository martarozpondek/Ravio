using Ravio.Entities;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Ravio.ViewModels
{
    public class WorkoutResultPageViewModel : BaseViewModel
    {
        public WorkoutResultPageViewModel()
        {
            Map = new Xamarin.Forms.Maps.Map();

            //TestMap();
            var startTime = new System.DateTime(2021, 07, 21, 14, 05, 00);
            var endTime = new System.DateTime(2021, 07, 21, 15, 05, 00);
            WorkoutResult = new WorkoutResultEntity() { Calories = 200, Distance = 20, StartTime = startTime, EndTime = endTime, Time = endTime - startTime};

            GoToHomePageCommand = new Command(GoToHomePage);
        }

        public async void TestMap()
        {
            Polyline Line = new Polyline() { StrokeColor = Color.Pink, StrokeWidth = 10 };

            while (true)
            {
                var Location = await Geolocation.GetLocationAsync();

                var PostionPoint = new Position(Location.Latitude, Location.Longitude);

                Map.MoveToRegion(new MapSpan(PostionPoint, 0.01, 0.01));

                Line.Geopath.Add(PostionPoint);
               
                Map.MapElements.Add(Line);

                await System.Threading.Tasks.Task.Delay(5000);

                Map.MapElements.Remove(Line);
            }
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

        public Command GoToHomePageCommand { get; set; }
        private async void GoToHomePage()
        {
            await Shell.Current.GoToAsync("../../");
        }
    }
}
