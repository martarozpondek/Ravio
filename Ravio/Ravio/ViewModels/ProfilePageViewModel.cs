using Ravio.Entities;
using Ravio.Repositories;
using Ravio.Requests;
using Ravio.Services;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    public class ProfilePageViewModel : BaseViewModel
    {
        public ProfilePageViewModel()
        {
            SignOutCommand = new Command(SignOut);
            SignDownCommand = new Command(SignDown);

        }

        private UserService UserService => DependencyService.Get<UserService>();
        private BodiesMessurementsRepository BodiesMessurementsRepository => DependencyService.Get<BodiesMessurementsRepository>();

        private UserEntity user;
        public UserEntity User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }

        private BodyMessurementsEntity bodyMessurements;
        public BodyMessurementsEntity BodyMessurements
        {
            get { return bodyMessurements; }
            set { SetProperty(ref bodyMessurements, value); }
        }

        public async Task GetUserByUserName()
        {
            User = await UserService.GetUserByUserName();

        }

        public async Task GetLastBodyMessurementsByUserName()
        {
            BodyMessurements = await BodiesMessurementsRepository.GetLastBodyMessurements();
        }

        public Command SignOutCommand { get; set; }
        private async void SignOut()
        {
            await UserService.SignOutAsync();
        }

        public Command SignDownCommand { get; set; }
        private async void SignDown()
        {
            await UserService.SignDownAsync();
        }
    }
}
