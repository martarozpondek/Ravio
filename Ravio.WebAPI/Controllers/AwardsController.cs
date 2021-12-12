using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ravio.Entities;
using Ravio.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Controllers
{
    [Route("[Controller]")]
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class AwardsController : ControllerBase
    {
        public AwardsController(IAwardsService awardsService, IWorkoutsResultsService workoutsResultsService, IExercisesResultsService exercisesResultsService, IFoodResultsService foodResultsService)
        {
            AwardsService = awardsService;
            WorkoutsResultsService = workoutsResultsService;
            ExercisesResultsService = exercisesResultsService;
            FoodResultsService = foodResultsService;
        }

        private IAwardsService AwardsService { get; }
        private IWorkoutsResultsService WorkoutsResultsService { get; }
        private IExercisesResultsService ExercisesResultsService { get; }
        private IFoodResultsService FoodResultsService { get; }

        [HttpGet("Workouts")]
        public async Task<List<AwardEntity>> GetWorkoutsAwardsByUserName()
        {
            return await AwardsService.GetWorkoutsAwardsByUserName(User.Identity.Name);
        }

        [HttpGet("Exercises")]
        public async Task<List<AwardEntity>> GetExercisesAwardsByUserName()
        {
            return await AwardsService.GetExercisesAwardsByUserName(User.Identity.Name);
        }

        [HttpGet("Food")]
        public async Task<List<AwardEntity>> GetFoodAwardsByUserName()
        {
            return await AwardsService.GetFoodAwardsByUserName(User.Identity.Name);
        }

        [HttpPost]
        public async Task PostAwardByUserName()
        {

        }

        [HttpPut("Workout")]
        public async Task PutWorkoutAwardByUserName()
        {
            // Kopiuj + wklej
        }

        [HttpPut("Exercise")]
        public async Task PutExerciseAwardByUserName()
        {
            // Kopiuj + wklej
        }

        [HttpPut("Food")]
        public async Task PutFoodAwardByUserName()
        {
            var foodResults = await FoodResultsService.GetFoodResultsByUserName(User.Identity.Name);

            var daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1);
            var resultsFromLastMonth = foodResults.Where(foodResult => foodResult.Date < foodResult.Date.AddMonths(-1) && foodResult.Date > foodResult.Date.AddDays(-1)).ToList();
            if (resultsFromLastMonth.Count == daysInMonth)
            {
                await AwardsService.LevelUpFoodAward(User.Identity.Name);
            }
        }
    }
}
