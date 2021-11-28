using System.Net.Http;
using System.Text.Json;
using Xamarin.Forms;

namespace Ravio.Repositories
{
    public class FoodResultsRepository
    {
        private HttpClient HttpClient => DependencyService.Get<HttpClient>();
        private JsonSerializerOptions JsonSerializerOptions => DependencyService.Get<JsonSerializerOptions>();
    }
}
