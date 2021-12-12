using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ravio.Entities;
using Ravio.WebAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Controllers
{
    [Route("[Controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class ExercisesResultsController : ControllerBase
    {
        public ExercisesResultsController(IExercisesResultsService exercisesResultsService)
        {
            ExercisesResultsService = exercisesResultsService;
        }

        private IExercisesResultsService ExercisesResultsService { get; }
        
        [HttpGet]
        public async Task<List<ExerciseResultEntity>> GetExercisesResultsByUserName()
        {
            return await ExercisesResultsService.GetExercisesResultsByUserName(User.Identity.Name);
        }

        [HttpPost]
        public async Task PostExerciseResultByUserName(ExerciseResultEntity exerciseResult)
        {
            await ExercisesResultsService.PostExerciseResultByUserName(exerciseResult, User.Identity.Name);
        }
    }
}
