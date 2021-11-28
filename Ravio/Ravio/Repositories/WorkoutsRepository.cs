using System.Net.Http;
using System.Text.Json;
using Xamarin.Forms;

namespace Ravio.Repositories
{
    public class WorkoutsRepository
    {
        private HttpClient HttpClient => DependencyService.Get<HttpClient>();
        private JsonSerializerOptions JsonSerializerOptions => DependencyService.Get<JsonSerializerOptions>();
    }
}
