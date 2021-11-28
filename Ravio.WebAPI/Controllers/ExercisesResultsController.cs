using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ravio.WebAPI.Services;

namespace Ravio.WebAPI.Controllers
{
    [Route("[Controller]")]
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class ExercisesResultsController : ControllerBase
    {
        public ExercisesResultsController(IExercisesResultsService exercisesResultsService)
        {
            ExercisesResultsService = exercisesResultsService;
        }

        private IExercisesResultsService ExercisesResultsService { get; }
    }
}
