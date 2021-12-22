using Ravio.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.Repositories
{
    public class FoodRepository
    {
        private HttpClient HttpClient => DependencyService.Get<HttpClient>();
        private JsonSerializerOptions JsonSerializerOptions => DependencyService.Get<JsonSerializerOptions>();

        public async Task<List<FoodEntity>> GetFood()
        {
            return await HttpClient.GetFromJsonAsync<List<FoodEntity>>("/Food", JsonSerializerOptions);
        }

        public async Task<FoodEntity> SearchFood(string searchString)
        {
            return await HttpClient.GetFromJsonAsync<FoodEntity>($"/Food/Search/{searchString}", JsonSerializerOptions);
        }
    }
}
