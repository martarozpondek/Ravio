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
            return new Position(location.Latitude, location.Longitude);
        }

        public async Task<double> GetUserSpeed()
        {
            var location = await Geolocation.GetLocationAsync();
            return location.Speed.Value;
        }

        public async Task<WorkoutResultEntity> FinishWorkout(WorkoutResultEntity workoutResult)
        {
            return await WorkoutsResultsRepository.Add(workoutResult);
        }

        public double CalculateDistanceBetweenPoints(ICollection<CoordinatesEntity> coordinates)
        {
            double Distance = 0;

            var CoordinatesList = coordinates.ToList();

            for (int Iterator = 0; Iterator < coordinates.Count; Iterator++)
            {
                Distance += Location.CalculateDistance(new Location(CoordinatesList[Iterator].Latitude, CoordinatesList[Iterator].Longitude), new Location(CoordinatesList[Iterator - 1].Latitude, CoordinatesList[Iterator - 1].Longitude), DistanceUnits.Kilometers);
            }

            return Distance;
        }
    }
}
