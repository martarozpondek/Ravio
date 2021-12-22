using Ravio.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.Repositories
{
    public class BodiesMessurementsRepository
    {
        private HttpClient HttpClient => DependencyService.Get<HttpClient>();
        private JsonSerializerOptions JsonSerializerOptions => DependencyService.Get<JsonSerializerOptions>();

        public async Task<List<BodyMessurementsEntity>> GetBodyMessurements()
        {
            return await HttpClient.GetFromJsonAsync<List<BodyMessurementsEntity>>($"/BodiesMessurements", JsonSerializerOptions);
        }

        public async Task<BodyMessurementsEntity> GetLastBodyMessurements()
        {
            return await HttpClient.GetFromJsonAsync<BodyMessurementsEntity>($"/BodiesMessurements/Last", JsonSerializerOptions);
        }

        public async Task PostBodyMessurementsByUserName(BodyMessurementsEntity bodyMessurements)
        {
            await HttpClient.PostAsJsonAsync("/BodiesMessurements", JsonSerializerOptions);
        }
    }
}
