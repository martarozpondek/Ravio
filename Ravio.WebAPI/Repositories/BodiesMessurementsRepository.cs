using Microsoft.EntityFrameworkCore;
using Ravio.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Repositories
{
    public interface IBodiesMessurementsRepository
    {
        Task<List<BodyMessurementsEntity>> GetBodyMessurementsByUserName(string userName);

        Task<BodyMessurementsEntity> GetLastBodyMessurementsByUserName(string userName);

        Task PostBodyMessurements(BodyMessurementsEntity bodyMessurements);
    }

    public class BodiesMessurementsRepository : IBodiesMessurementsRepository
    {
        public BodiesMessurementsRepository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        private DatabaseContext DatabaseContext { get; }

        public async Task<List<BodyMessurementsEntity>> GetBodyMessurementsByUserName(string userName)
        {
            return await DatabaseContext.BodiesMessurements.Where(bodyMessurement => bodyMessurement.User.UserName == userName).ToListAsync();
        }

        public async Task<BodyMessurementsEntity> GetLastBodyMessurementsByUserName(string userName)
        {
            return await DatabaseContext.BodiesMessurements.LastAsync(bodyMessurement => bodyMessurement.User.UserName == userName);
        }

        public async Task PostBodyMessurements(BodyMessurementsEntity bodyMessurements)
        {
            await DatabaseContext.BodiesMessurements.AddAsync(bodyMessurements);
            await DatabaseContext.SaveChangesAsync();
        }
    }
}
