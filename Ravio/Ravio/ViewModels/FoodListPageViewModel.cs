using Ravio.Entities;
using Ravio.Requests;
using Ravio.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    public class FoodListPageViewModel : BaseViewModel
    {
        public FoodListPageViewModel()
        {
            GoToSearchFoodPageCommand = new Command<string>(GoToSearchFoodPage);
        }

        private FoodResultsService FoodResultsService => DependencyService.Get<FoodResultsService>();

        private FoodResultEntity foodResult;
        public FoodResultEntity FoodResult
        {
            get { return foodResult; }
            set { SetProperty(ref foodResult, value); }
        }

        private List<AddedFoodEntity> breakfastList;
        public List<AddedFoodEntity> BreakfastList
        {
            get { return breakfastList; }
            set { SetProperty(ref breakfastList, value); }
        }

        private List<AddedFoodEntity> lunchList;
        public List<AddedFoodEntity> LunchList
        {
            get { return lunchList; }
            set { SetProperty(ref lunchList, value); }
        }

        private List<AddedFoodEntity> dinnerList;
        public List<AddedFoodEntity> DinnerList
        {
            get { return dinnerList; }
            set { SetProperty(ref dinnerList, value); }
        }

        private List<AddedFoodEntity> supperList;
        public List<AddedFoodEntity> SupperList
        {
            get { return supperList; }
            set { SetProperty(ref supperList, value); }
        }

        private List<AddedFoodEntity> snackList;
        public List<AddedFoodEntity> SnackList
        {
            get { return snackList; }
            set { SetProperty(ref snackList, value); }
        }

        public async Task GetFoodResult()
        {
            FoodResult = await FoodResultsService.GetCurrentFoodResult();

            BreakfastList = FoodResult.AddedFood.Where(food => food.Type == FoodType.Breakfast).ToList();
            LunchList = FoodResult.AddedFood.Where(food => food.Type == FoodType.Lunch).ToList();
            DinnerList = FoodResult.AddedFood.Where(food => food.Type == FoodType.Dinner).ToList();
            SupperList = FoodResult.AddedFood.Where(food => food.Type == FoodType.Supper).ToList();
            SnackList = FoodResult.AddedFood.Where(food => food.Type == FoodType.Snacks).ToList();
        }

        public Command<string> GoToSearchFoodPageCommand { get; set; }
        private async void GoToSearchFoodPage(string foodTypeName)
        {
            await Shell.Current.GoToAsync($"SearchFoodPage?FoodType={foodTypeName}");
        }
    }
}
