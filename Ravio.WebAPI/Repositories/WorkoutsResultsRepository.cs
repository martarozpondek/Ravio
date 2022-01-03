using Microsoft.EntityFrameworkCore;
using Ravio.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Repositories
{
    public interface IWorkoutsResultsRepository
    {
        Task<WorkoutResultEntity> GetWorkoutResultById(int id);
        Task<List<WorkoutResultEntity>> GetWorkoutsResultsByUserName(string userName);
        Task PostWorkoutResultByUserName(WorkoutResultEntity workoutResult, string userName);
    }

    public class WorkoutsResultsRepository : IWorkoutsResultsRepository
    {
        public WorkoutsResultsRepository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        private DatabaseContext DatabaseContext { get; }

        public async Task<WorkoutResultEntity> GetWorkoutResultById(int id)
        {
            return await DatabaseContext.WorkoutsResults.Include(workoutResult => workoutResult.Workout).Include(workoutResult => workoutResult.Coordinates).FirstOrDefaultAsync(workoutResult => workoutResult.Id == id);
        }

        public async Task<List<WorkoutResultEntity>> GetWorkoutsResultsByUserName(string userName)
        {
            return await DatabaseContext.WorkoutsResults.Include(workoutResult => workoutResult.Workout).Include(workoutResult => workoutResult.Coordinates).Where(workoutResult => workoutResult.User.UserName == userName).ToListAsync();
        }

        public async Task PostWorkoutResultByUserName(WorkoutResultEntity workoutResult, string userName)
        {
            workoutResult.User = await DatabaseContext.Accounts.FirstOrDefaultAsync(account => account.UserName == userName);

            await DatabaseContext.WorkoutsResults.AddAsync(workoutResult);

            await DatabaseContext.SaveChangesAsync();
        }
    }
}
