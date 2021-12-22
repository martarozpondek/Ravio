using Microsoft.EntityFrameworkCore;
using Ravio.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Repositories
{
    public interface IFoodRepository
    {
        Task<List<FoodEntity>> GetFood();

        Task<FoodEntity> GetFood(int id);

        Task<FoodEntity> SearchFood(string searchString);
    }

    public class FoodRepository : IFoodRepository
    {
        public FoodRepository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        private DatabaseContext DatabaseContext { get; }

        public async Task<List<FoodEntity>> GetFood()
        {
            return await DatabaseContext.Food.ToListAsync();
        }

        public async Task<FoodEntity> GetFood(int id)
        {
            return await DatabaseContext.Food.FindAsync(id);
        }

        public async Task<FoodEntity> SearchFood(string searchString)
        {
            return await DatabaseContext.Food.FirstOrDefaultAsync(food => food.Name.Contains(searchString));
        }
    }
}
