using Ravio.Entities;
using Ravio.WebAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Services
{
    public interface IWorkoutsResultsService
    {
        Task<WorkoutResultEntity> GetWorkoutResultById(int id);

        Task<List<WorkoutResultEntity>> GetWorkoutsResultsByUserName(string userName);

        Task PostWorkoutResultByUserName(WorkoutResultEntity workoutResult, string userName);
    }

    public class WorkoutsResultsService : IWorkoutsResultsService
    {
        public WorkoutsResultsService(IWorkoutsResultsRepository workoutsResultsRepository)
        {
            WorkoutsResultsRepository = workoutsResultsRepository;
        }

        private IWorkoutsResultsRepository WorkoutsResultsRepository { get; }

        public async Task<WorkoutResultEntity> GetWorkoutResultById(int id)
        {
            return await WorkoutsResultsRepository.GetWorkoutResultById(id);
        }

        public async Task<List<WorkoutResultEntity>> GetWorkoutsResultsByUserName(string userName)
        {
            return await WorkoutsResultsRepository.GetWorkoutsResultsByUserName(userName);
        }

        public async Task PostWorkoutResultByUserName(WorkoutResultEntity workoutResult, string userName)
        {
            await WorkoutsResultsRepository.PostWorkoutResultByUserName(workoutResult, userName);
        }
    }
}
