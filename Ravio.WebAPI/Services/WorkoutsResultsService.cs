using Ravio.WebAPI.Repositories;

namespace Ravio.WebAPI.Services
{
    public interface IWorkoutsResultsService
    {

    }

    public class WorkoutsResultsService : IWorkoutsResultsService
    {
        public WorkoutsResultsService(IWorkoutsResultsRepository workoutsResultsRepository)
        {
            WorkoutsResultsRepository = workoutsResultsRepository;
        }

        private IWorkoutsResultsRepository WorkoutsResultsRepository { get; }
    }
}
