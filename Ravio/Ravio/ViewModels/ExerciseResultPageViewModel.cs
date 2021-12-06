﻿using Ravio.Entities;
using Ravio.Services;
using Xamarin.Forms;

namespace Ravio.ViewModels
{
    [QueryProperty(nameof(ExerciseResultId), "id")]
    public class ExerciseResultPageViewModel : BaseViewModel
    {
        public ExerciseResultPageViewModel()
        {
            GoToHomePageCommand = new Command(GoToHomePage);

            GetExerciseResult();
        }

        private ExercisesResultsService ExercisesResultsService => DependencyService.Get<ExercisesResultsService>();

        private int exerciseResultid;
        public int ExerciseResultId
        {
            get { return exerciseResultid; }
            set { SetProperty(ref exerciseResultid, value); }
        }

        private ExerciseResultEntity exerciseResult;
        public ExerciseResultEntity ExerciseResult
        {
            get { return exerciseResult; }
            set { SetProperty(ref exerciseResult, value); }
        }

        public async void GetExerciseResult()
        {
            ExerciseResult = await ExercisesResultsService.GetById(ExerciseResultId);
        }

        public Command GoToHomePageCommand { get; set; }
        private async void GoToHomePage()
        {
            await Shell.Current.GoToAsync("../../");
        }
    }
}