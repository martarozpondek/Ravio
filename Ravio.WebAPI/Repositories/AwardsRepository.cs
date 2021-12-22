using Microsoft.EntityFrameworkCore;
using Ravio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Repositories
{
    public interface IAwardsRepository
    {
        Task<List<AwardEntity>> GetWorkoutsAwardsByUserName(string userName);

        Task<List<AwardEntity>> GetExercisesAwardsByUserName(string userName);

        Task<List<AwardEntity>> GetFoodAwardsByUserName(string userName);

        Task PostAwardByUserName(AwardEntity award, string userName);

        Task PutAward(AwardEntity award);
    }

    public class AwardsRepository : IAwardsRepository
    {
        public AwardsRepository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        private DatabaseContext DatabaseContext { get; }

        public async Task<List<AwardEntity>> GetWorkoutsAwardsByUserName(string userName)
        {
            return await DatabaseContext.Awards.Where(award => award.User.UserName == userName && award.Type == AwardType.Workouts).ToListAsync();
        }

        public async Task<List<AwardEntity>> GetExercisesAwardsByUserName(string userName)
        {
            return await DatabaseContext.Awards.Where(award => award.User.UserName == userName && award.Type == AwardType.Exercises).ToListAsync();
        }

        public async Task<List<AwardEntity>> GetFoodAwardsByUserName(string userName)
        {
            return await DatabaseContext.Awards.Where(award => award.User.UserName == userName && award.Type == AwardType.Food).ToListAsync();
        }

        public async Task<AwardEntity> GetEnabledWorkoutAward(string userName)
        {
            return await DatabaseContext.Awards.FirstOrDefaultAsync(award => award.User.UserName == userName && award.Type == AwardType.Workouts && award.IsEnabled == true);
        }

        public async Task<AwardEntity> GetEnabledExerciseAward(string userName)
        {
            return await DatabaseContext.Awards.FirstOrDefaultAsync(award => award.User.UserName == userName && award.Type == AwardType.Exercises && award.IsEnabled == true);
        }

        public async Task<AwardEntity> GetEnabledFoodAward(string userName)
        {
            return await DatabaseContext.Awards.FirstOrDefaultAsync(award => award.User.UserName == userName && award.Type == AwardType.Food && award.IsEnabled == true);
        }

        public async Task PostAwardByUserName(AwardEntity award, string userName)
        {
            award.User = await DatabaseContext.Accounts.FirstOrDefaultAsync(account => account.UserName == userName);

            await DatabaseContext.Awards.AddAsync(award);

            await DatabaseContext.SaveChangesAsync();
        }

        public async Task PutAward(AwardEntity award)
        {
            DatabaseContext.Awards.Update(award);

            await DatabaseContext.SaveChangesAsync();
        }
    }
}
