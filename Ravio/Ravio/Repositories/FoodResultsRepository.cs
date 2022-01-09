using Ravio.Entities;
using Ravio.Requests;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.Repositories
{
    public class FoodResultsRepository
    {
        private HttpClient HttpClient => DependencyService.Get<HttpClient>();
        private JsonSerializerOptions JsonSerializerOptions => DependencyService.Get<JsonSerializerOptions>();

        public async Task<List<FoodResultEntity>> GetFoodResultsById(int id)
        {
            return await HttpClient.GetFromJsonAsync<List<FoodResultEntity>>("/FoodResults", JsonSerializerOptions);
        }
        public async Task<List<FoodResultEntity>> GetFoodResultsByUserName()
        {
            return await HttpClient.GetFromJsonAsync<List<FoodResultEntity>>("/FoodResults", JsonSerializerOptions);
        }

        public async Task<FoodResultEntity> GetCurrentFoodResult()
        {
            return await HttpClient.GetFromJsonAsync<FoodResultEntity>("/FoodResults/Current", JsonSerializerOptions);
        }

        public async Task PostFoodResult(FoodResultEntity foodResult)
        {
            await HttpClient.PostAsJsonAsync("/FoodResults", foodResult, JsonSerializerOptions);
        }
    }
}
