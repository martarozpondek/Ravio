using Ravio.Entities;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Repositories
{
    public interface IAddedFoodRepository
    {
        Task AddAddedFood(AddedFoodEntity addedFood);
    }

    public class AddedFoodRepository : IAddedFoodRepository
    {
        public AddedFoodRepository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        private DatabaseContext DatabaseContext { get; }

        public async Task AddAddedFood(AddedFoodEntity addedFood)
        {
            await DatabaseContext.AddedFood.AddAsync(addedFood);

            await DatabaseContext.SaveChangesAsync();
        }
    }
}
