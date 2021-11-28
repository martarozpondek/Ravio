namespace Ravio.WebAPI.Repositories
{
    public interface IWorkoutsResultsRepository
    {

    }

    public class WorkoutsResultsRepository : IWorkoutsResultsRepository
    {
        public WorkoutsResultsRepository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        private DatabaseContext DatabaseContext { get; }
    }
}
