using Microsoft.EntityFrameworkCore;
using Ravio.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Repositories
{
    public interface IExercisesResultsRepository
    {
        Task<ExerciseResultEntity> GetExerciseResultById(int id);

        Task<List<ExerciseResultEntity>> GetExercisesResultsByUserName(string userName);
        
        Task<ExerciseResultEntity> PostExerciseResultByUserName(ExerciseResultEntity exerciseResult, string userName);
    }

    public class ExercisesResultsRepository : IExercisesResultsRepository
    {
        public ExercisesResultsRepository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        private DatabaseContext DatabaseContext { get; }


        public async Task<ExerciseResultEntity> GetExerciseResultById(int id)
        {
            return await DatabaseContext.ExercisesResults.Include(exerciseResult => exerciseResult.Exercise).FirstOrDefaultAsync(workoutResult => workoutResult.Id == id);
        }

        public async Task<List<ExerciseResultEntity>> GetExercisesResultsByUserName(string userName)
        {
            return await DatabaseContext.ExercisesResults.Include(exercise => exercise.Exercise).Where(exerciseResult => exerciseResult.User.UserName == userName).ToListAsync();
        }

        public async Task<ExerciseResultEntity> PostExerciseResultByUserName(ExerciseResultEntity exerciseResult, string userName)
        {
            var user = await DatabaseContext.Accounts.FirstOrDefaultAsync(account => account.UserName == userName);
            exerciseResult.UserId = user.Id;

            var result = await DatabaseContext.ExercisesResults.AddAsync(exerciseResult);

            await DatabaseContext.SaveChangesAsync();

            var data = await DatabaseContext.ExercisesResults.Include(x => x.Exercise).FirstOrDefaultAsync(x => x.Id == result.Entity.Id);
            data.User = null;
            return data;
        }
    }
}
