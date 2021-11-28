using Microsoft.EntityFrameworkCore;
using Ravio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Repositories
{
    public interface IWorkoutsRepository
    {
        Task<List<WorkoutEntity>> GetWorkouts();

        Task<WorkoutEntity> GetWorkout(int id);
    }

    public class WorkoutsRepository : IWorkoutsRepository
    {
        public WorkoutsRepository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        private DatabaseContext DatabaseContext { get; }

        public async Task<List<WorkoutEntity>> GetWorkouts()
        {
            return await DatabaseContext.Workouts.ToListAsync();
        }

        public async Task<WorkoutEntity> GetWorkout(int id)
        {
            return await DatabaseContext.Workouts.FindAsync(id);
        }
    }
}
