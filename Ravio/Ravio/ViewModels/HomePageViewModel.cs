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
    }
}
