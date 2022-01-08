using Ravio.Entities;
using Ravio.Repositories;
using Ravio.Services;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    [QueryProperty(nameof(FoodTypeName), "FoodType")]
    public class SearchFoodPageViewModel : BaseViewModel
    {
        public SearchFoodPageViewModel()
        {
            SearchFoodCommand = new Command(SearchFood);

            AddFoodCommand = new Command(AddFood);
        }

        private FoodResultsService FoodResultsService => DependencyService.Get<FoodResultsService>();

        private FoodRepository FoodRepository => DependencyService.Get<FoodRepository>();

        private AddedFoodRepository AddedFoodRepository => DependencyService.Get<AddedFoodRepository>();

        private string searchString;
        public string SearchString
        {
            get { return searchString; }
            set { SetProperty(ref searchString, value); }
        }

        private FoodEntity searchedfood;
        public FoodEntity SearchedFood
        {
            get { return searchedfood; }
            set { SetProperty(ref searchedfood, value); }
        }

        private string foodTypeName;
        public string FoodTypeName
        {
            get { return foodTypeName; }
            set { SetProperty(ref foodTypeName, value); }
        }

        public Command SearchFoodCommand { get; set; }
        private async void SearchFood()
        {
            SearchedFood = await FoodRepository.SearchFood(searchString);
        }

        public Command AddFoodCommand { get; set; }
        private async void AddFood()
        {
            var foodResult = await FoodResultsService.GetCurrentFoodResult();

            await AddedFoodRepository.AddFood(new AddedFoodEntity() { FoodResultId = foodResult.Id,  Name = SearchedFood.Name, Calories = SearchedFood.Calories, Grams = SearchedFood.Grams, Type = (FoodType)Enum.Parse(typeof(FoodType), FoodTypeName, true) });

            await Shell.Current.GoToAsync("FoodPage");
        }
    }
}
