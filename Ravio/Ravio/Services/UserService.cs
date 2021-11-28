using Ravio.Requests;
using Ravio.Responses;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.Services
{
    public class UserService
    {
        private HttpClient HttpClient => DependencyService.Get<HttpClient>();
        private JsonSerializerOptions JsonSerializerOptions => DependencyService.Get<JsonSerializerOptions>();

        public async Task<UserSignInResponse> SignInAsync(UserSignInRequest request)
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserSignUpResponse> SignUpAsync(UserSignUpRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
