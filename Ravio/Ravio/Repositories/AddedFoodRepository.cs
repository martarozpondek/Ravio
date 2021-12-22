using Ravio.Entities;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.Repositories
{
    public class AddedFoodRepository
    {
        private HttpClient HttpClient => DependencyService.Get<HttpClient>();
        private JsonSerializerOptions JsonSerializerOptions => DependencyService.Get<JsonSerializerOptions>();

        public async Task AddFood(AddedFoodEntity food)
        {
            await HttpClient.PostAsJsonAsync("/AddedFood", food, JsonSerializerOptions);
        }
    }
}
