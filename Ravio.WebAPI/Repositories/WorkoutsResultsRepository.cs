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
        Task<WorkoutResultEntity> PostWorkoutResultByUserName(WorkoutResultEntity workoutResult, string userName);
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
            return await DatabaseContext.WorkoutsResults.Include(workoutResult => workoutResult.Workout).FirstOrDefaultAsync(workoutResult => workoutResult.Id == id);
        }

        public async Task<List<WorkoutResultEntity>> GetWorkoutsResultsByUserName(string userName)
        {
            return await DatabaseContext.WorkoutsResults.Include(workoutResult => workoutResult.Workout).Where(workoutResult => workoutResult.User.UserName == userName).ToListAsync();
        }

        public async Task<WorkoutResultEntity> PostWorkoutResultByUserName(WorkoutResultEntity workoutResult, string userName)
        {
            var user = await DatabaseContext.Accounts.FirstOrDefaultAsync(account => account.UserName == userName);
            workoutResult.UserId = user.Id;

            var result = await DatabaseContext.WorkoutsResults.AddAsync(workoutResult);

            await DatabaseContext.SaveChangesAsync();

            var data = await DatabaseContext.WorkoutsResults.Include(x => x.Workout).FirstOrDefaultAsync(x => x.Id == result.Entity.Id);
            data.User = null;
            return data;
        }
    }
}
