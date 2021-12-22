using Ravio.Entities;
using Ravio.Repositories;
using Ravio.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.Services
{
    public class FoodResultsService
    {
        private FoodResultsRepository FoodResultsRepository => DependencyService.Get<FoodResultsRepository>();

        public async Task<List<FoodResultEntity>> GetById(int id)
        {
            return await FoodResultsRepository.GetFoodResultsById(id);
        }
        public async Task<List<FoodResultEntity>> GetByUserName()
        {
            return await FoodResultsRepository.GetFoodResultsByUserName();
        }

        public async Task<FoodResultEntity> GetCurrentFoodResult()
        {
            return await FoodResultsRepository.GetCurrentFoodResult();
        }

        public async Task PostFoodResult(FoodResultEntity foodResult)
        {
            await FoodResultsRepository.PostFoodResult(foodResult);
        }
    }
}
