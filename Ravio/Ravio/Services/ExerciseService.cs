using Ravio.Entities;
using Ravio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.Services
{
    public class ExerciseService
    {
        private ExercisesResultsRepository ExercisesResultsRepository => DependencyService.Get<ExercisesResultsRepository>();

        public async Task<ExerciseResultEntity> FinishExercise(ExerciseResultEntity exerciseResult)
        {
            return await ExercisesResultsRepository.Add(exerciseResult);
        }
    }
}
