using Ravio.Entities;
using Ravio.Repositories;
using Ravio.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    public class ExercisesStatisticsPageViewModel : BaseViewModel
    {
        public ExercisesStatisticsPageViewModel()
        {

            Awards = new ObservableCollection<AwardEntity>();
            ExercisesResults = new ObservableCollection<ExerciseResultEntity>();
            Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 });
            Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 }); Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 }); Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 }); Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 }); Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 }); Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 }); Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 }); Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 });
            ExercisesResults.Add(new ExerciseResultEntity() { NumberOfRepetitions =20, Calories=5, Time= new System.TimeSpan(0,1,0) });
        }

        private ExercisesResultsService ExercisesResultsService => DependencyService.Get<ExercisesResultsService>();
        private AwardsRepository AwardsRepository => DependencyService.Get<AwardsRepository>();

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
