using Microsoft.EntityFrameworkCore;
using Ravio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Repositories
{
    public interface IFoodResultsRepository
    {
        Task<List<FoodResultEntity>> GetFoodResultsByUserName(string userName);

        Task<FoodResultEntity> GetCurrentFoodResult(string userName);

        Task PostFoodResultByUserName(FoodResultEntity foodResult, string userName);
    }

    public class FoodResultsRepository : IFoodResultsRepository
    {
        public FoodResultsRepository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        private DatabaseContext DatabaseContext { get; }

        public async Task<List<FoodResultEntity>> GetFoodResultsByUserName(string userName)
        {
            return await DatabaseContext.FoodResults.Include(foodResult => foodResult.AddedFood).Where(foodResult => foodResult.User.UserName == userName).ToListAsync();
        }

        public async Task<FoodResultEntity> GetCurrentFoodResult(string userName)
        {
            return DatabaseContext.FoodResults.Include(foodResult => foodResult.AddedFood).FirstOrDefault(foodResult => foodResult.User.UserName == userName && foodResult.Date.Date == DateTime.Now.Date);
        }

        public async Task PostFoodResultByUserName(FoodResultEntity foodResult, string userName)
        {
            if (await GetCurrentFoodResult(userName) == null)
            {
                var user = await DatabaseContext.Accounts.FirstOrDefaultAsync(account => account.UserName == userName);
                foodResult.UserId = user.Id;

                await DatabaseContext.FoodResults.AddAsync(foodResult);

                await DatabaseContext.SaveChangesAsync();
            }
        }
    }
}

