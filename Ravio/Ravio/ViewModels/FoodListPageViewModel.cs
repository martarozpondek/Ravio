using Ravio.Entities;
using Ravio.Services;
using System.Collections.Generic;
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

        private List<FoodEntity> breakfastList;
        public List<FoodEntity> BreakfastList
        {
            get { return breakfastList; }
            set { SetProperty(ref breakfastList, value); }
        }

        private List<FoodEntity> lunchList;
        public List<FoodEntity> LunchList
        {
            get { return lunchList; }
            set { SetProperty(ref lunchList, value); }
        }

        private List<FoodEntity> dinnerList;
        public List<FoodEntity> DinnerList
        {
            get { return dinnerList; }
            set { SetProperty(ref dinnerList, value); }
        }

        private List<FoodEntity> supperList;
        public List<FoodEntity> SupperList
        {
            get { return supperList; }
            set { SetProperty(ref supperList, value); }
        }

        private List<FoodEntity> snackList;
        public List<FoodEntity> SnackList
        {
            get { return snackList; }
            set { SetProperty(ref snackList, value); }
        }

        public Command<string> GoToSearchFoodPageCommand { get; set; }
        private async void GoToSearchFoodPage(string foodTypeName)
        {
            await Shell.Current.GoToAsync($"SearchFoodPage?FoodType={foodTypeName}");
        }
    }
}
