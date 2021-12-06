using Ravio.Entities;
using Ravio.Repositories;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.Services
{
    public class WorkoutsResultsService
    {
        private WorkoutsResultsRepository WorkoutsResultsRepository => DependencyService.Get<WorkoutsResultsRepository>();

        public async Task<WorkoutResultEntity> GetById(int id)
        {
            return await WorkoutsResultsRepository.GetById(id);
        }
    }
}
