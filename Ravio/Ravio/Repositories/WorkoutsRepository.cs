using Ravio.Entities;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.Repositories
{
    public class WorkoutsRepository
    {
        private HttpClient HttpClient => DependencyService.Get<HttpClient>();
        private JsonSerializerOptions JsonSerializerOptions => DependencyService.Get<JsonSerializerOptions>();

        public async Task<WorkoutEntity> GetByName(string name)
        {
            return await HttpClient.GetFromJsonAsync<WorkoutEntity>($"/Workouts/{name}", JsonSerializerOptions);
        }
    }
}
