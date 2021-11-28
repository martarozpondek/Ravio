using Microsoft.AspNetCore.Mvc;
using Ravio.Entities;
using Ravio.WebAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        public FoodController(IFoodRepository foodRepository)
        {
            FoodRepository = foodRepository;
        }

        private IFoodRepository FoodRepository { get; }

        [HttpGet]
        public async Task<List<FoodEntity>> GetFood()
        {
            return await FoodRepository.GetFood();
        }

        [HttpGet("{id}")]
        public async Task<FoodEntity> GetFood(int id)
        {
            return await FoodRepository.GetFood(id);
        }
    }
}
