using Ravio.Entities;
using Ravio.Repositories;
using Ravio.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    public class WorkoutsStatisticsPageViewModel : BaseViewModel
    {
        public WorkoutsStatisticsPageViewModel()
        {
            Awards = new ObservableCollection<AwardEntity>();
            WorkoutsResults = new ObservableCollection<WorkoutResultEntity>();
            Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 });
            Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 });Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 });Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 });Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 });Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 });Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 });Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 });Awards.Add(new AwardEntity() { Date = System.DateTime.Now, Level = 2 });
            WorkoutsResults.Add(new WorkoutResultEntity() { Calories = 5, Distance = 25, StartTime = System.DateTime.Now, EndTime = System.DateTime.Now, Workout = new WorkoutEntity() { Name = "Rower" } });WorkoutsResults.Add(new WorkoutResultEntity() { Calories = 5, Distance = 25, StartTime = System.DateTime.Now, EndTime = System.DateTime.Now, Workout = new WorkoutEntity() { Name = "Rower" } });WorkoutsResults.Add(new WorkoutResultEntity() { Calories = 5, Distance = 25, StartTime = System.DateTime.Now, EndTime = System.DateTime.Now, Workout = new WorkoutEntity() { Name = "Rower" } });WorkoutsResults.Add(new WorkoutResultEntity() { Calories = 5, Distance = 25, StartTime = System.DateTime.Now, EndTime = System.DateTime.Now, Workout = new WorkoutEntity() { Name = "Rower" } });
        }

        private WorkoutsResultsService WorkoutsResultsService => DependencyService.Get<WorkoutsResultsService>();
        private AwardsRepository AwardsRepository => DependencyService.Get<AwardsRepository>();

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
