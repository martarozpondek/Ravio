using Ravio.Repositories;
using Ravio.Services;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ravio
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.RegisterSingleton(new HttpClient() { BaseAddress = new Uri("http://192.168.2.50") });
            DependencyService.RegisterSingleton(new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.Preserve, PropertyNameCaseInsensitive = true, WriteIndented = true });

            DependencyService.Register<UserService>();
            DependencyService.Register<GendersRepository>();
            DependencyService.Register<LifestyleTypesRepository>();
            DependencyService.Register<TargetTypesRepository>();
            DependencyService.Register<BodiesMessurementsRepository>();
            DependencyService.Register<AwardsService>();
            DependencyService.Register<AwardsRepository>();

            DependencyService.Register<NewsRepository>();

            DependencyService.Register<WorkoutsRepository>();
            DependencyService.Register<ExercisesRepository>();
            DependencyService.Register<FoodRepository>();
            DependencyService.Register<AddedFoodRepository>();

            DependencyService.Register<WorkoutsResultsRepository>();
            DependencyService.Register<ExercisesResultsRepository>();
            DependencyService.Register<FoodResultsRepository>();

            DependencyService.Register<WorkoutService>();
            DependencyService.Register<ExerciseService>();

            DependencyService.Register<WorkoutsResultsService>();
            DependencyService.Register<ExercisesResultsService>();
            DependencyService.Register<FoodResultsService>();

            MainPage = new AppShell();
        }


        private HttpClient HttpClient => DependencyService.Get<HttpClient>();

        protected override async void OnStart()
        {
            if (await SecureStorage.GetAsync("Token") != null)
            {
                await Shell.Current.GoToAsync("//HomePage");
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("Token"));
            }
        }
    }
}
