using Ravio.Repositories;
using Ravio.Services;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xamarin.Forms;

namespace Ravio
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.RegisterSingleton(new HttpClient() { BaseAddress = new Uri("https://SERVER-ROBIRT") });
            DependencyService.RegisterSingleton(new JsonSerializerOptions() { WriteIndented = true, ReferenceHandler = ReferenceHandler.Preserve, PropertyNameCaseInsensitive = true });

            DependencyService.Register<UserService>();
            DependencyService.Register<GendersRepository>();
            DependencyService.Register<BodiesMessurementsRepository>();
            DependencyService.Register<AwardsRepository>();

            DependencyService.Register<NewsRepository>();

            DependencyService.Register<WorkoutsRepository>();
            DependencyService.Register<ExercisesRepository>();
            DependencyService.Register<FoodRepository>();

            DependencyService.Register<WorkoutsResultsRepository>();
            DependencyService.Register<ExercisesResultsRepository>();
            DependencyService.Register<FoodResultsRepository>();

            DependencyService.Register<WorkoutsResultsService>();
            DependencyService.Register<ExercisesResultsService>();
            DependencyService.Register<FoodResultsService>();

            MainPage = new AppShell();
        }
    }
}
