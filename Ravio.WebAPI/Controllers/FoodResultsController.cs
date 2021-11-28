using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ravio.WebAPI.Services;

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
    }
}
