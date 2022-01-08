using Ravio.Entities;
using Ravio.Services;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Ravio.ViewModels
{
    [QueryProperty(nameof(WorkoutResultId), "id")]
    public class WorkoutResultPageViewModel : BaseViewModel
    {
        public WorkoutResultPageViewModel()
        {
            Map = new Xamarin.Forms.Maps.Map();

            GoToHomePageCommand = new Command(GoToHomePage);
        }

        private WorkoutsResultsService WorkoutsResultsService => DependencyService.Get<WorkoutsResultsService>();

        private int workoutResultid;
        public int WorkoutResultId
        {
            get { return workoutResultid; }
            set { SetProperty(ref workoutResultid, value); }
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

        public async Task CreateMapLine()
        {
            Polyline Line = new Polyline() { StrokeColor = Color.Purple, StrokeWidth = 10 };
            foreach (var coordinates in WorkoutResult.Coordinates)
            {
                var position = new Position(coordinates.Latitude, coordinates.Longitude);
                Line.Geopath.Add(position);
            }

            Map.MapElements.Add(Line);
        }

        public async Task GetWorkoutResult()
        {
            WorkoutResult = await WorkoutsResultsService.GetById(WorkoutResultId);
        }

        public Command GoToHomePageCommand { get; set; }
        private async void GoToHomePage()
        {
            await Shell.Current.GoToAsync("///HomePage");
        }
    }
}
