using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ravio.Entities;
using Ravio.Requests;
using Ravio.WebAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Controllers
{
    [Route("[Controller]")]
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class FoodResultsController : ControllerBase
    {
        public FoodResultsController(IFoodResultsService foodResultsService)
        {
            FoodResultsService = foodResultsService;
        }

        private IFoodResultsService FoodResultsService { get; }

        [HttpGet]
        public async Task<List<FoodResultEntity>> GetFoodResultsByUserName()
        {
            return await FoodResultsService.GetFoodResultsByUserName(User.Identity.Name);
        }

        [HttpGet("Current")]
        public async Task<FoodResultEntity> GetCurrentFoodResult()
        {
            return await FoodResultsService.GetCurrentFoodResult(User.Identity.Name);
        }

        [HttpPost]
        public async Task PostFoodResultByUserName(FoodResultEntity foodResult)
        {
            await FoodResultsService.PostFoodResultByUserName(foodResult, User.Identity.Name);
        }
    }
}
