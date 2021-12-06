using Ravio.Entities;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.Repositories
{
    public class ExercisesResultsRepository
    {
        private HttpClient HttpClient => DependencyService.Get<HttpClient>();
        private JsonSerializerOptions JsonSerializerOptions => DependencyService.Get<JsonSerializerOptions>();

        public async Task<ExerciseResultEntity> GetById(int id)
        {
            return await HttpClient.GetFromJsonAsync<ExerciseResultEntity>($"/ExercisesResults/{id}", JsonSerializerOptions);
        }

        public async Task<ExerciseResultEntity> Add(ExerciseResultEntity exerciseResult)
        {
            var response = await HttpClient.PostAsJsonAsync("/ExercisesResults", exerciseResult, JsonSerializerOptions);
            return await response.Content.ReadFromJsonAsync<ExerciseResultEntity>();
        }
    }
}
