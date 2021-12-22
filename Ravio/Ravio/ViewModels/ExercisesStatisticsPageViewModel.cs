using Ravio.Entities;
using Ravio.Repositories;
using Ravio.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    public class ExercisesStatisticsPageViewModel : BaseViewModel
    {
        public ExercisesStatisticsPageViewModel()
        {
            GetExerciseResults();
            GetExerciseAwards();
        }

        private ExercisesResultsService ExercisesResultsService => DependencyService.Get<ExercisesResultsService>();
        private AwardsService AwardsService => DependencyService.Get<AwardsService>();

        public async Task GetExerciseResults()
        {
            ExercisesResults = new ObservableCollection<ExerciseResultEntity>(await ExercisesResultsService.GetByUserName());
        }

        public async Task GetExerciseAwards()
        {
            Awards = new ObservableCollection<AwardEntity>(await AwardsService.GetExercisesAwardsByUserName());
        }

        private ObservableCollection<ExerciseResultEntity> exercisesResults;
        public ObservableCollection<ExerciseResultEntity> ExercisesResults
        {
            get { return exercisesResults; }
            set { SetProperty(ref exercisesResults, value); }
        }

        private ObservableCollection<AwardEntity> awards;
        public ObservableCollection<AwardEntity> Awards
        {
            get { return awards; }
            set { SetProperty(ref awards, value); }
        }
    }
}
