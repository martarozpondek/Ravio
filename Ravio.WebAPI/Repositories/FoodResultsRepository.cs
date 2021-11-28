namespace Ravio.WebAPI.Repositories
{
    public interface IFoodResultsRepository
    {

    }

    public class FoodResultsRepository : IFoodResultsRepository
    {
        public FoodResultsRepository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        private DatabaseContext DatabaseContext { get; }
    }
}
