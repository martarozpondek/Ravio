using Ravio.Entities;
using Ravio.Repositories;
using Ravio.Requests;
using Ravio.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    public class WelcomePageViewModel : BaseViewModel
    {
        public WelcomePageViewModel()
        {
            CompleteProfileCommand = new Command(CompleteProfile);
            CompleteProfileRequest = new UserCompleteProfileRequest();

            GetLifestyleTypes();
            GetTargetTypes();
        }

        private UserService UserService => DependencyService.Get<UserService>();
        private LifestyleTypesRepository LifestyleTypesRepository => DependencyService.Get<LifestyleTypesRepository>();
        private TargetTypesRepository TargetTypesRepository => DependencyService.Get<TargetTypesRepository>();

        private UserCompleteProfileRequest completeProfileRequest;
        public UserCompleteProfileRequest CompleteProfileRequest
        {
            get { return completeProfileRequest; }
            set { SetProperty(ref completeProfileRequest, value); }
        }

        private List<LifestyleType> lifestyleTypes;
        public List<LifestyleType> LifestyleTypes
        {
            get { return lifestyleTypes; }
            set { SetProperty(ref lifestyleTypes, value); }
        }

        private async Task GetLifestyleTypes()
        {
            LifestyleTypes = await LifestyleTypesRepository.GetLifestyleTypes();
        }

        private List<TargetType> targetTypes;
        public List<TargetType> TargetTypes
        {
            get { return targetTypes; }
            set { SetProperty(ref targetTypes, value); }
        }

        private async Task GetTargetTypes()
        {
            TargetTypes = await TargetTypesRepository.GetTargetTypes();
        }

        public Command CompleteProfileCommand { get; set; }
        private async void CompleteProfile()
        {           
            var Response = await UserService.CompleteProfileAsync(CompleteProfileRequest);
            if (Response.IsSucceeded)
            {
                await SecureStorage.SetAsync("Weight", Convert.ToString(CompleteProfileRequest.Weight));
                await SecureStorage.SetAsync("Height", Convert.ToString(CompleteProfileRequest.Height));
                await SecureStorage.SetAsync("Target", CompleteProfileRequest.Target.Name);
                await SecureStorage.SetAsync("Lifestyle", Convert.ToString(CompleteProfileRequest.Lifestyle.Parameter));
                await Shell.Current.GoToAsync("//////HomePage");
            }

            CompleteProfileRequest = new UserCompleteProfileRequest();
        }
    }
}
