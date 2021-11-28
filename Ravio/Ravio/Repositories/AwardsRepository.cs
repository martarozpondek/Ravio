using Ravio.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.Repositories
{
    public class AwardsRepository
    {
        private HttpClient HttpClient => DependencyService.Get<HttpClient>();
        private JsonSerializerOptions JsonSerializerOptions => DependencyService.Get<JsonSerializerOptions>();

        public async Task<List<AwardEntity>> GetAwardsForWorkouts()
        {
            return await HttpClient.GetFromJsonAsync<List<AwardEntity>>("/Awards/Workouts", JsonSerializerOptions);
        }

        public async Task<List<AwardEntity>> GetAwardsForExercises()
        {
            return await HttpClient.GetFromJsonAsync<List<AwardEntity>>("/Awards/Exercises", JsonSerializerOptions);
        }

        public async Task<List<AwardEntity>> GetAwardsForFood()
        {
            return await HttpClient.GetFromJsonAsync<List<AwardEntity>>("/Awards/Food", JsonSerializerOptions);
        }
    }
}
