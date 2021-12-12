using Ravio.Requests;
using Ravio.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    public class ProfilePageViewModel : BaseViewModel
    {
        public ProfilePageViewModel()
        {
            SignOutCommand = new Command(SignOut);
        }

        private UserService UserService => DependencyService.Get<UserService>();

        public Command SignOutCommand { get; set; }
        private async void SignOut()
        {
            await UserService.SignOutAsync();
        }

        public Command SignDownCommand { get; set; }
        private async void SignDown()
        {
            await UserService.SignDownAsync(new UserSignDownRequest(await SecureStorage.GetAsync("UserName")));
        }
    }
}
