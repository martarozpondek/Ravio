using Ravio.Entities;
using Ravio.Repositories;
using Ravio.Requests;
using Ravio.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    public class SignUpPageViewModel : BaseViewModel
    {
        public SignUpPageViewModel()
        {
            UserSignUpRequest = new UserSignUpRequest();

            SignUpCommand = new Command(SignUp);

            GetGenderTypes();
        }

        private UserService UserService => DependencyService.Get<UserService>();

        private GendersRepository GendersRepository => DependencyService.Get<GendersRepository>();

        private HttpClient HttpClient => DependencyService.Get<HttpClient>();

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

        private string error;
        public string Error
        {
            get { return error; }
            set { SetProperty(ref error, value); }
        }

        private async void GetGenderTypes()
        {
            Genders = await GendersRepository.GetGenderTypes();
        }

        public Command SignUpCommand { get; set; }
        private async void SignUp()
        {
            UserSignUpRequest.GenderTypeId += 1;
            var Response = await UserService.SignUpAsync(UserSignUpRequest);
            if (Response.IsSucceeded)
            {
                await SecureStorage.SetAsync("UserName", UserSignUpRequest.UserName);
                await SecureStorage.SetAsync("GenderName", Response.GenderName);
                await SecureStorage.SetAsync("Age", Convert.ToString(Response.Age));
                await SecureStorage.SetAsync("Token", Response.Token);
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Response.Token);
                await Shell.Current.GoToAsync("//WelcomePage");
            }
            else
            {
                Error = Response.Error;
            }

            UserSignUpRequest = new UserSignUpRequest();
        }
    }
}
