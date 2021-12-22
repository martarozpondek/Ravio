using Ravio.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.Repositories
{
    public class ExercisesRepository
    {
        private HttpClient HttpClient => DependencyService.Get<HttpClient>();
        private JsonSerializerOptions JsonSerializerOptions => DependencyService.Get<JsonSerializerOptions>();

        public async Task<List<ExerciseEntity>> GetAll()
        {
            return await HttpClient.GetFromJsonAsync<List<ExerciseEntity>>("/Exercises", JsonSerializerOptions);
        }

        public async Task<ExerciseEntity> GetByName(string name)
        {
            return await HttpClient.GetFromJsonAsync<ExerciseEntity>($"/Exercises/{name}", JsonSerializerOptions);
        }
    }
}
