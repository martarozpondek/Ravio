using Ravio.WebAPI.Repositories;

namespace Ravio.WebAPI.Services
{
    public interface IExercisesResultsService
    {

    }

    public class ExercisesResultsService : IExercisesResultsService
    {
        public ExercisesResultsService(IExercisesResultsRepository exercisesResultsRepository)
        {
            ExercisesResultsRepository = exercisesResultsRepository;
        }

        private IExercisesResultsRepository ExercisesResultsRepository { get; }
    }
}
