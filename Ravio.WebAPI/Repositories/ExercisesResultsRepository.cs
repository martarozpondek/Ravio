using Microsoft.EntityFrameworkCore;
using Ravio.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Repositories
{
    public interface IExercisesResultsRepository
    {
        Task<List<ExerciseResultEntity>> GetExercisesResultsByUserName(string userName);
        
        Task PostExerciseResultByUserName(ExerciseResultEntity exerciseResult, string userName);
    }

    public class ExercisesResultsRepository : IExercisesResultsRepository
    {
        public ExercisesResultsRepository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        private DatabaseContext DatabaseContext { get; }

        public async Task<List<ExerciseResultEntity>> GetExercisesResultsByUserName(string userName)
        {
            return await DatabaseContext.ExercisesResults.Where(exerciseResult => exerciseResult.User.UserName == userName).ToListAsync();
        }

        public async Task PostExerciseResultByUserName(ExerciseResultEntity exerciseResult, string userName)
        {
            exerciseResult.User = await DatabaseContext.Accounts.FirstOrDefaultAsync(account => account.UserName == userName);

            await DatabaseContext.ExercisesResults.AddAsync(exerciseResult);

            await DatabaseContext.SaveChangesAsync();
        }
    }
}
