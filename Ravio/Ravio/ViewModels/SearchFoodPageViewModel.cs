using Ravio.Entities;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    [QueryProperty(nameof(FoodTypeName), "FoodType")]
    public class SearchFoodPageViewModel : BaseViewModel
    {
        public SearchFoodPageViewModel()
        {

        }

        private string searchString;
        public string SearchString
        {
            get { return searchString; }
            set { SetProperty(ref searchString, value); }
        }

        private FoodEntity food;
        public FoodEntity Food
        {
            get { return food; }
            set { SetProperty(ref food, value); }
        }

        private string foodTypeName;
        public string FoodTypeName
        {
            get { return foodTypeName; }
            set { SetProperty(ref foodTypeName, value); }
        }
    }
}
