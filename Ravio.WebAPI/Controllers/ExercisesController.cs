using Microsoft.AspNetCore.Mvc;
using Ravio.Entities;
using Ravio.WebAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        public ExercisesController(IExercisesRepository exercisesRepository)
        {
            ExercisesRepository = exercisesRepository;
        }

        private IExercisesRepository ExercisesRepository { get; }

        [HttpGet]
        public async Task<List<ExerciseEntity>> GetExercises()
        {
            return await ExercisesRepository.GetExercises();
        }

        [HttpGet("{exerciseName}")]
        public async Task<ExerciseEntity> GetExerciseByName(string exerciseName)
        {
            return await ExercisesRepository.GetExerciseByName(exerciseName);
        }
    }
}
