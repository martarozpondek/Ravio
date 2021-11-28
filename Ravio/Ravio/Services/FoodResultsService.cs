using Ravio.Repositories;
using Xamarin.Forms;

namespace Ravio.Services
{
    public class FoodResultsService
    {
        private FoodResultsRepository FoodResultsRepository => DependencyService.Get<FoodResultsRepository>();
    }
}
