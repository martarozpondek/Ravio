using Xamarin.Forms;

namespace Ravio.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public HomePageViewModel()
        {
            GoToComponentCommand = new Command<string>(GoToComponent);
        }

        public Command<string> GoToComponentCommand { get; set; }
        private async void GoToComponent(string componentName)
        {
            await Shell.Current.GoToAsync(componentName);
        }

        public Command<string> DisplayTokenCommand { get; set; }
        private async void DisplayToken()
        {
            await Shell.Current.DisplayAlert("Token", await Xamarin.Essentials.SecureStorage.GetAsync("Token"), "Ok");
        }
    }
}
