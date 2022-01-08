using Ravio.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.Repositories
{
    public class WorkoutsResultsRepository
    {
        private HttpClient HttpClient => DependencyService.Get<HttpClient>();
        private JsonSerializerOptions JsonSerializerOptions => DependencyService.Get<JsonSerializerOptions>();

        public async Task<WorkoutResultEntity> GetById(int id)
        {
            return await HttpClient.GetFromJsonAsync<WorkoutResultEntity>($"/WorkoutsResults/{id}", JsonSerializerOptions);
        }

        public async Task<List<WorkoutResultEntity>> GetByUserName()
        {
            return await HttpClient.GetFromJsonAsync<List<WorkoutResultEntity>>("/WorkoutsResults", JsonSerializerOptions);
        }

        public async Task<WorkoutResultEntity> Add(WorkoutResultEntity workoutResult)
        {
            var response = await HttpClient.PostAsJsonAsync("/WorkoutsResults", workoutResult, JsonSerializerOptions);
            return await response.Content.ReadFromJsonAsync<WorkoutResultEntity>();
        }
    }
}
