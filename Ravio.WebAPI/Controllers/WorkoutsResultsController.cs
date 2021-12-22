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
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class WorkoutsResultsController : ControllerBase
    {
        public WorkoutsResultsController(IWorkoutsResultsService workoutsResultsService)
        {
            WorkoutsResultsService = workoutsResultsService;
        }

        private IWorkoutsResultsService WorkoutsResultsService { get; }

        [HttpGet("{id}")]
        public async Task<WorkoutResultEntity> GetWorkoutResultById(int id)
        {
            return await WorkoutsResultsService.GetWorkoutResultById(id);
        }

        [HttpGet]
        public async Task<List<WorkoutResultEntity>> GetWorkoutResultsByUserName()
        {
            return await WorkoutsResultsService.GetWorkoutsResultsByUserName(User.Identity.Name);
        }

        [HttpPost]
        public async Task PostWorkoutResultByUserName(WorkoutResultEntity workoutResult)
        {
            await WorkoutsResultsService.PostWorkoutResultByUserName(workoutResult, User.Identity.Name);
        }
    }
}
