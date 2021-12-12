using Ravio.Requests;
using Ravio.Responses;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ravio.Services
{
    public class UserService
    {
        private HttpClient HttpClient => DependencyService.Get<HttpClient>();
        private JsonSerializerOptions JsonSerializerOptions => DependencyService.Get<JsonSerializerOptions>();

        public async Task<UserSignInResponse> SignInAsync(UserSignInRequest request)
        {
            var response = await HttpClient.PostAsJsonAsync("/Users/SignIn", request, JsonSerializerOptions);
            
            return await response.Content.ReadFromJsonAsync<UserSignInResponse>(JsonSerializerOptions);
        }

        public async Task<UserSignUpResponse> SignUpAsync(UserSignUpRequest request)
        {
            var response = await HttpClient.PostAsJsonAsync("/Users/SignUp", request, JsonSerializerOptions);

            return await response.Content.ReadFromJsonAsync<UserSignUpResponse>(JsonSerializerOptions);
        }

        public async Task SignOutAsync()
        {
            SecureStorage.RemoveAll();

            await Shell.Current.GoToAsync("///StartPage");
        }

        public async Task<UserSignDownResponse> SignDownAsync(UserSignDownRequest request)
        {
            var response = await HttpClient.PostAsJsonAsync("/Users/SignDown", request, JsonSerializerOptions);

            return await response.Content.ReadFromJsonAsync<UserSignDownResponse>(JsonSerializerOptions);
        }
    }
}
