using Ravio.Entities;
using Ravio.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Ravio.Services
{
    public class WorkoutService
    {
        private WorkoutsResultsRepository WorkoutsResultsRepository => DependencyService.Get<WorkoutsResultsRepository>();

        public async Task<Position> GetUserPosition()
        {
            var location = await Geolocation.GetLocationAsync();
            if (location == null)
            {
                string s = "";
            }
            return new Position(location.Latitude, location.Longitude);
        }

        public async Task<double> GetUserSpeed()
        {
            var location = await Geolocation.GetLocationAsync();
            if (location == null)
            {
                string s = "";
            }
            if (location.Speed == null)
            {
                return 0.0;
            }
            return location.Speed.Value;
        }

        public async Task<WorkoutResultEntity> FinishWorkout(WorkoutResultEntity workoutResult)
        {
            return await WorkoutsResultsRepository.Add(workoutResult);
        }

        public double CalculateDistanceBetweenPoints(List<Position> positions)
        {
            double Distance = 0;

            for (int Iterator = 1; Iterator < positions.Count; Iterator++)
            {
                Distance += Location.CalculateDistance(new Location(positions[Iterator].Latitude, positions[Iterator].Longitude), new Location(positions[Iterator - 1].Latitude, positions[Iterator - 1].Longitude), DistanceUnits.Kilometers);
            }

            return Distance;
        }
    }
}
