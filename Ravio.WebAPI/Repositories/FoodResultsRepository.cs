using Microsoft.EntityFrameworkCore;
using Ravio.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Repositories
{
    public interface IFoodResultsRepository
    {
        Task<List<FoodResultEntity>> GetFoodResultsByUserName(string userName);

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
            return await DatabaseContext.FoodResults.Where(foodResult => foodResult.User.UserName == userName).ToListAsync();
        }

        public async Task PostFoodResultByUserName(FoodResultEntity foodResult, string userName)
        {
            foodResult.User = await DatabaseContext.Accounts.FirstOrDefaultAsync(account => account.UserName == userName);

            await DatabaseContext.FoodResults.AddAsync(foodResult);

            await DatabaseContext.SaveChangesAsync();
        }
    }
}

