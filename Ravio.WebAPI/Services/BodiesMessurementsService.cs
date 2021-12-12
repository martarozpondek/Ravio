using Ravio.Entities;
using Ravio.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Services
{
    public interface IBodiesMessuerementsService
    {
        Task<List<BodyMessurementsEntity>> GetBodyMessurementsByUserName(string userName);

        Task<BodyMessurementsEntity> GetLastBodyMessurementsByUserName(string userName);

        Task PostBodyMessurementsByUserName(BodyMessurementsEntity bodyMessurements, string userName);
    }

    public class BodiesMessurementsService : IBodiesMessuerementsService
    {
        public BodiesMessurementsService(IBodiesMessurementsRepository bodiesMessurementsRepository)
        {
            BodiesMessurementsRepository = bodiesMessurementsRepository;
        }

        private IBodiesMessurementsRepository BodiesMessurementsRepository { get; }

        public async Task<List<BodyMessurementsEntity>> GetBodyMessurementsByUserName(string userName)
        {
            return await BodiesMessurementsRepository.GetBodyMessurementsByUserName(userName);
        }

        public async Task<BodyMessurementsEntity> GetLastBodyMessurementsByUserName(string userName)
        {
            return await BodiesMessurementsRepository.GetLastBodyMessurementsByUserName(userName);
        }

        public async Task PostBodyMessurementsByUserName(BodyMessurementsEntity bodyMessurements, string userName)
        {
            await BodiesMessurementsRepository.PostBodyMessurementsByUserName(bodyMessurements, userName);
        }
    }
}
