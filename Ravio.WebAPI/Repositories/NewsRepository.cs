using Ravio.Entities;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Repositories
{
    public interface INewsRepository
    {
        Task<NewsEntity> GetNews();
    }

    public class NewsRepository : INewsRepository
    {
        private HttpClient HttpClient { get; }

        public NewsRepository(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<NewsEntity> GetNews()
        {
            return await HttpClient.GetFromJsonAsync<NewsEntity>("https://newsapi.org/v2/top-headlines?country=pl&apiKey=66c23059de4f4dddb4560a8f135edc9d", new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }

}
