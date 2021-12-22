using Ravio.Entities;
using Ravio.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public HomePageViewModel()
        {
            GoToComponentCommand = new Command<string>(GoToComponent);

            AddFoodResult();

            CheckWorkoutAward();
            CheckExerciseAward();
            CheckFoodAward();
        }

        private WorkoutsResultsService WorkoutsResultsService => DependencyService.Get<WorkoutsResultsService>();
        private ExercisesResultsService ExercisesResultsService => DependencyService.Get<ExercisesResultsService>();
        private FoodResultsService FoodResultsService => DependencyService.Get<FoodResultsService>();

        private AwardsService AwardsService => DependencyService.Get<AwardsService>();

        public async Task AddFoodResult()
        {
            Device.StartTimer(TimeSpan.FromMinutes(1), () =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (DateTime.Now.TimeOfDay == new TimeSpan(0, 0, 0))
                    {
                        int targetCalories = 0;

                        if (await SecureStorage.GetAsync("Gender") == "Female")
                        {
                            targetCalories = (int)((10 * (Convert.ToInt32(await SecureStorage.GetAsync("Weight")))) + (6.25 * (Convert.ToInt32(await SecureStorage.GetAsync("Height")))) - (5 * (Convert.ToInt32(await SecureStorage.GetAsync("Age")))) - 161)* (Convert.ToInt32(await SecureStorage.GetAsync("Lifestyle")));
                        }
                        if (await SecureStorage.GetAsync("Gender") == "Male")
                        {
                            targetCalories = (int)((10 * (Convert.ToInt32(await SecureStorage.GetAsync("Weight")))) + (6.25 * (Convert.ToInt32(await SecureStorage.GetAsync("Height")))) - (5 * (Convert.ToInt32(await SecureStorage.GetAsync("Age")))) +5) * (Convert.ToInt32(await SecureStorage.GetAsync("Lifestyle")));
                        }

                        var foodResult = new FoodResultEntity() { TargetCalories = targetCalories, Date = DateTime.Now };
                        await FoodResultsService.PostFoodResult(foodResult);
                    }
                });
                return true;
            });
        }

        public async Task CheckWorkoutAward()
        {
            Device.StartTimer(TimeSpan.FromMinutes(1), () =>
            {
                if (DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) == DateTime.Now.Day && DateTime.Now.TimeOfDay == new TimeSpan(0, 0, 0))
                {
                    AwardsService.CheckWorkoutAward();
                }

                return true;
            });
        }

        public async Task CheckExerciseAward()
        {
            Device.StartTimer(TimeSpan.FromMinutes(1), () =>
            {
                if (DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) == DateTime.Now.Day && DateTime.Now.TimeOfDay == new TimeSpan(0, 0, 0))
                {
                    AwardsService.CheckExerciseAward();
                }

                return true;
            });
        }

        public async Task CheckFoodAward()
        {
            Device.StartTimer(TimeSpan.FromMinutes(1), () =>
            {
                if (DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) == DateTime.Now.Day && DateTime.Now.TimeOfDay == new TimeSpan(0, 0, 0))
                {
                    AwardsService.CheckFoodAward();
                }

                return true;
            });
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
