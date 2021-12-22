using Ravio.Entities;
using Ravio.Repositories;
using System.Collections.Generic;
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

        public async Task<List<ExerciseResultEntity>> GetByUserName()
        {
            return await ExercisesResultsRepository.GetByUserName();
        }
    }
}
