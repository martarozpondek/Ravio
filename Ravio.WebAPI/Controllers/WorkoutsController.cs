using Microsoft.AspNetCore.Mvc;
using Ravio.Entities;
using Ravio.WebAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        public WorkoutsController(IWorkoutsRepository workoutsRepository)
        {
            WorkoutsRepository = workoutsRepository;
        }

        private IWorkoutsRepository WorkoutsRepository { get; }

        [HttpGet]
        public async Task<List<WorkoutEntity>> GetWorkouts()
        {
            return await WorkoutsRepository.GetWorkouts();
        }

        [HttpGet("{workoutName}")]
        public async Task<WorkoutEntity> GetWorkoutByName(string workoutName)
        {
            return await WorkoutsRepository.GetWorkoutByName(workoutName);
        }
    }
}
