using Ravio.Entities;
using Ravio.Repositories;
using Ravio.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    public class FoodStatisticsPageViewModel : BaseViewModel
    {
        public FoodStatisticsPageViewModel()
        {
            GetFoodResults();
            GetFoodAwards();
        }

        private FoodResultsService FoodResultsService => DependencyService.Get<FoodResultsService>();
        private AwardsService AwardsService => DependencyService.Get<AwardsService>();

        public async Task GetFoodResults()
        {
            FoodResults = new ObservableCollection<FoodResultEntity>(await FoodResultsService.GetByUserName());
        }

        public async Task GetFoodAwards()
        {
            Awards = new ObservableCollection<AwardEntity>(await AwardsService.GetFoodAwardsByUserName());
        }

        private ObservableCollection<FoodResultEntity> foodResults;
        public ObservableCollection<FoodResultEntity> FoodResults
        {
            get { return foodResults; }
            set { SetProperty(ref foodResults, value); }
        }

        private ObservableCollection<AwardEntity> awards;
        public ObservableCollection<AwardEntity> Awards
        {
            get { return awards; }
            set { SetProperty(ref awards, value); }
        }
    }
}
