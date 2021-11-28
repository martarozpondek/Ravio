using Ravio.Entities;
using Ravio.Repositories;
using Ravio.Requests;
using Ravio.Services;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    public class SignUpPageViewModel : BaseViewModel
    {
        public SignUpPageViewModel()
        {
            UserSignUpRequest = new UserSignUpRequest();

            SignUpCommand = new Command(SignUp);
        }

        private UserService UserService => DependencyService.Get<UserService>();

        private GendersRepository GendersRepository => DependencyService.Get<GendersRepository>();

        private UserSignUpRequest userSignUpRequest;
        public UserSignUpRequest UserSignUpRequest
        {
            get { return userSignUpRequest; }
            set { SetProperty(ref userSignUpRequest, value); }
        }

        private List<GenderType> genders;
        public List<GenderType> Genders
        {
            get { return genders; }
            set { SetProperty(ref genders, value); }
        }

        public Command SignUpCommand { get; set; }
        private async void SignUp()
        {

        }
    }
}
