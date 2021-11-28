using Ravio.Requests;
using Ravio.Services;
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

        private UserService UsersService => DependencyService.Get<UserService>();

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
            await Shell.Current.GoToAsync("/SignUpPage");
        }

        public Command SignInCommand { get; set; }
        private async void SignIn()
        {
            //var Response = await UsersService.SignInAsync(UserSignInRequest);
            //if (Response.IsSucceeded)
            //{
            //    await SecureStorage.SetAsync("Token", Response.Token);
            //    await Shell.Current.GoToAsync("///HomePage");
            //}
            //else
            //{
            //    Error = Response.Error;
            //}

            //UserSignInRequest.UserName = userSignInRequest.Password = string.Empty;

            await Shell.Current.GoToAsync("///HomePage");
        }
    }
}
