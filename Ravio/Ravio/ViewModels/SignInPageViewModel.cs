using Ravio.Requests;
using Ravio.Services;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    public class SignInPageViewModel : BaseViewModel
    {
        public SignInPageViewModel()
        {
            UserSignInRequest = new UserSignInRequest();

            SignInCommand = new Command(SignIn);
            GoToSignUpPageCommand = new Command(GoToSignUpPage);
        }

        private UserService UserService => DependencyService.Get<UserService>();

        private HttpClient HttpClient => DependencyService.Get<HttpClient>();

        private UserSignInRequest userSignInRequest;
        public UserSignInRequest UserSignInRequest
        {
            get { return userSignInRequest; }
            set { SetProperty(ref userSignInRequest, value); }
        }

        private string error;
        public string Error
        {
            get { return error; }
            set { SetProperty(ref error, value); }
        }

        public Command GoToSignUpPageCommand { get; set; }
        private async void GoToSignUpPage()
        {
            await Shell.Current.GoToAsync("//SignUpPage");
        }

        public Command SignInCommand { get; set; }
        private async void SignIn()
        {
            var Response = await UserService.SignInAsync(UserSignInRequest);
            if (Response.IsSucceeded)
            {
                await SecureStorage.SetAsync("Token", Response.Token);
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Response.Token);
                await Shell.Current.GoToAsync("//HomePage");
            }
            else
            {
                Error = Response.Error;
            }

            Error = string.Empty;
            UserSignInRequest = new UserSignInRequest();
        }
    }
}
