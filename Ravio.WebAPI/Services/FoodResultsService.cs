using Ravio.WebAPI.Repositories;

namespace Ravio.WebAPI.Services
{
    public interface IFoodResultsService
    {

    }

    public class FoodResultsService : IFoodResultsService
    {
        public FoodResultsService(IFoodResultsRepository foodResultsRepository)
        {
            FoodResultsRepository = foodResultsRepository;
        }

        private IFoodResultsRepository FoodResultsRepository { get; }
    }
}
