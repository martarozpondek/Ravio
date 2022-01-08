using Microsoft.EntityFrameworkCore;
using Ravio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Repositories
{
    public interface IExercisesRepository
    {
        Task<List<ExerciseEntity>> GetExercises();

        Task<ExerciseEntity> GetExerciseByName(string name);
    }

    public class ExercisesRepository : IExercisesRepository
    {
        public ExercisesRepository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        private DatabaseContext DatabaseContext { get; }

        public async Task<List<ExerciseEntity>> GetExercises()
        {
            return await DatabaseContext.Exercises.ToListAsync();
        }

        public async Task<ExerciseEntity> GetExerciseByName(string name)
        {
            return await DatabaseContext.Exercises.FirstOrDefaultAsync(exercise => exercise.Name == name);
        }
    }
}
