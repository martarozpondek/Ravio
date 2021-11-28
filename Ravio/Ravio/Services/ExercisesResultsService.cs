using Ravio.Repositories;
using Xamarin.Forms;

namespace Ravio.Services
{
    public class ExercisesResultsService
    {
        private ExercisesResultsRepository ExercisesResultsRepository => DependencyService.Get<ExercisesResultsRepository>();
    }
}
