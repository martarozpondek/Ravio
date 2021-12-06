using Ravio.Entities;
using Ravio.Repositories;
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

        public async Task<WorkoutResultEntity> FinishWorkout(WorkoutResultEntity workoutResult)
        {
            return await WorkoutsResultsRepository.Add(workoutResult);
        }
    }
}
