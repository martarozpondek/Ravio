using Microsoft.AspNetCore.Mvc;
using Ravio.Entities;
using Ravio.WebAPI.Repositories;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class AddedFoodController : ControllerBase
    {
        public AddedFoodController(IAddedFoodRepository addedFoodRepository)
        {
            AddedFoodRepository = addedFoodRepository;
        }

        private IAddedFoodRepository AddedFoodRepository { get; }

        [HttpPost]
        public async Task PostFood(AddedFoodEntity addedFood)
        {
            await AddedFoodRepository.AddAddedFood(addedFood);
        }
    }
}
