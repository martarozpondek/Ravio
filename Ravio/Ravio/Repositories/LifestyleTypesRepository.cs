using Ravio.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.Repositories
{
    public class LifestyleTypesRepository
    {
        private HttpClient HttpClient => DependencyService.Get<HttpClient>();
        private JsonSerializerOptions JsonSerializerOptions => DependencyService.Get<JsonSerializerOptions>();

        public async Task<List<LifestyleType>> GetLifestyleTypes()
        {
            return await HttpClient.GetFromJsonAsync<List<LifestyleType>>("AccountDetailsTypes/Lifestyles", JsonSerializerOptions);
        }
    }
}
