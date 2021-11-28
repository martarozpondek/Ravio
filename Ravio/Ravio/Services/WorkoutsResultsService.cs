using Ravio.Repositories;
using Xamarin.Forms;

namespace Ravio.Services
{
    public class WorkoutsResultsService
    {
        private WorkoutsResultsRepository WorkoutsResultsRepository => DependencyService.Get<WorkoutsResultsRepository>();
    }
}
