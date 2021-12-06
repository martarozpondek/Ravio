﻿using Ravio.Entities;
using Ravio.Repositories;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.Services
{
    public class ExercisesResultsService
    {
        private ExercisesResultsRepository ExercisesResultsRepository => DependencyService.Get<ExercisesResultsRepository>();

        public async Task<ExerciseResultEntity> GetById(int id)
        {
            return await ExercisesResultsRepository.GetById(id);
        }
    }
}
