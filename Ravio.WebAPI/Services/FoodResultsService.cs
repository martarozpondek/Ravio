using Ravio.Entities;
using Ravio.WebAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Services
{
    public interface IFoodResultsService
    {
        Task<List<FoodResultEntity>> GetFoodResultsByUserName(string userName);

        Task PostFoodResultByUserName(FoodResultEntity foodResult, string userName);
    }

    public class FoodResultsService : IFoodResultsService
    {
        public FoodResultsService(IFoodResultsRepository foodResultsRepository)
        {
            FoodResultsRepository = foodResultsRepository;
        }

        private IFoodResultsRepository FoodResultsRepository { get; }

        public async Task<List<FoodResultEntity>> GetFoodResultsByUserName(string userName)
        {
            return await FoodResultsRepository.GetFoodResultsByUserName(userName);
        }

        public async Task PostFoodResultByUserName(FoodResultEntity foodResult, string userName)
        {
            await FoodResultsRepository.PostFoodResultByUserName(foodResult, userName);
        }
    }
}
