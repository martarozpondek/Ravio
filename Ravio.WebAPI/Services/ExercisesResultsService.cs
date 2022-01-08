using Ravio.Entities;
using Ravio.WebAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Services
{
    public interface IExercisesResultsService
    {
        Task<ExerciseResultEntity> GetExerciseResultById(int id);

        Task<List<ExerciseResultEntity>> GetExercisesResultsByUserName(string userName);

        Task<ExerciseResultEntity> PostExerciseResultByUserName(ExerciseResultEntity exerciseResult, string userName);
    }

    public class ExercisesResultsService : IExercisesResultsService
    {
        public ExercisesResultsService(IExercisesResultsRepository exercisesResultsRepository)
        {
            ExercisesResultsRepository = exercisesResultsRepository;
        }

        private IExercisesResultsRepository ExercisesResultsRepository { get; }

        public async Task<ExerciseResultEntity> GetExerciseResultById(int id)
        {
            return await ExercisesResultsRepository.GetExerciseResultById(id);
        }

        public async Task<List<ExerciseResultEntity>> GetExercisesResultsByUserName(string userName)
        {
            return await ExercisesResultsRepository.GetExercisesResultsByUserName(userName);
        }

        public async Task<ExerciseResultEntity> PostExerciseResultByUserName(ExerciseResultEntity exerciseResult, string userName)
        {
            return await ExercisesResultsRepository.PostExerciseResultByUserName(exerciseResult, userName);
        }
    }
}
