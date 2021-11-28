using Ravio.Entities;
using Ravio.Repositories;
using Ravio.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    public class FoodStatisticsPageViewModel : BaseViewModel
    {
        public FoodStatisticsPageViewModel()
        {

            Awards = new ObservableCollection<AwardEntity>();
            FoodResults = new ObservableCollection<FoodResultEntity>();
            Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 });
            Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 }); Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 }); Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 }); Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 }); Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 }); Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 }); Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 }); Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 });
            FoodResults.Add(new FoodResultEntity() {Calories = 1300, TargetCalories=1400, Date = System.DateTime.Now });
        }

        private FoodResultsService FoodResultsService => DependencyService.Get<FoodResultsService>();
        private AwardsRepository AwardsRepository => DependencyService.Get<AwardsRepository>();

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
