using Ravio.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.Repositories
{
    public class TargetTypesRepository
    {
        private HttpClient HttpClient => DependencyService.Get<HttpClient>();
        private JsonSerializerOptions JsonSerializerOptions => DependencyService.Get<JsonSerializerOptions>();

        public async Task<List<TargetType>> GetTargetTypes()
        {
            return await HttpClient.GetFromJsonAsync<List<TargetType>>("AccountDetailsTypes/Targets", JsonSerializerOptions);
        }
    }
}
