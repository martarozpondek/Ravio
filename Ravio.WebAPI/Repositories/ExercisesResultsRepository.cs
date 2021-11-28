namespace Ravio.WebAPI.Repositories
{
    public interface IExercisesResultsRepository
    {

    }

    public class ExercisesResultsRepository : IExercisesResultsRepository
    {
        public ExercisesResultsRepository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        private DatabaseContext DatabaseContext { get; }
    }
}
