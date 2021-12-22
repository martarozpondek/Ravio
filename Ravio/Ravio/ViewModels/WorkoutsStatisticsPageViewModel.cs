using Ravio.Entities;
using Ravio.Repositories;
using Ravio.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    public class WorkoutsStatisticsPageViewModel : BaseViewModel
    {
        public WorkoutsStatisticsPageViewModel()
        {
            GetWorkoutsResults();
            GetWorkoutsAwards();
        }

        private WorkoutsResultsService WorkoutsResultsService => DependencyService.Get<WorkoutsResultsService>();
        private AwardsRepository AwardsService => DependencyService.Get<AwardsRepository>();

        public async Task GetWorkoutsResults()
        {
            WorkoutsResults = new ObservableCollection<WorkoutResultEntity>(await WorkoutsResultsService.GetByUserName());
        }

        public async Task GetWorkoutsAwards()
        {
            Awards = new ObservableCollection<AwardEntity>(await AwardsService.GetAwardsForWorkouts());
        }

        private ObservableCollection<WorkoutResultEntity> workoutsResults;
        public ObservableCollection<WorkoutResultEntity> WorkoutsResults
        {
            get { return workoutsResults; }
            set { SetProperty(ref workoutsResults, value); }
        }

        private ObservableCollection<AwardEntity> awards;
        public ObservableCollection<AwardEntity> Awards
        {
            get { return awards; }
            set { SetProperty(ref awards, value); }
        }
    }
}
