using Xamarin.Forms;

namespace Ravio.ViewModels
{
    public class StartPageViewModel : BaseViewModel
    {
        public StartPageViewModel()
        {
            GoToSignInPageCommand = new Command(GoToSignInPage);
            GoToSignUpPageCommand = new Command(GoToSignUpPage);
        }

        public Command GoToSignInPageCommand { get; set; }
        private async void GoToSignInPage()
        {
            await Shell.Current.GoToAsync("SignInPage");
        }

        public Command GoToSignUpPageCommand { get; set; }
        private async void GoToSignUpPage()
        {
            await Shell.Current.GoToAsync("SignUpPage");
        }
    }
}
