using Microsoft.EntityFrameworkCore;
using Ravio.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Repositories
{
    public interface IBodiesMessurementsRepository
    {
        Task<List<BodyMessurementsEntity>> GetBodyMessurements(int userId);

        Task<BodyMessurementsEntity> GetLastBodyMessurement(int userId);

        Task PostBodyMessurement(BodyMessurementsEntity bodyMessurements);
    }

    public class BodiesMessurementsRepository : IBodiesMessurementsRepository
    {
        public BodiesMessurementsRepository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        private DatabaseContext DatabaseContext { get; }

        public async Task<List<BodyMessurementsEntity>> GetBodyMessurements(int userId)
        {
            return await DatabaseContext.BodiesMessurements.Where(bodyMessurement => bodyMessurement.UserId == userId).ToListAsync();
        }

        public async Task<BodyMessurementsEntity> GetLastBodyMessurement(int userId)
        {
            return await DatabaseContext.BodiesMessurements.LastAsync(bodyMessurement => bodyMessurement.UserId == userId);
        }

        public async Task PostBodyMessurement(BodyMessurementsEntity bodyMessurements)
        {
            await DatabaseContext.BodiesMessurements.AddAsync(bodyMessurements);
            await DatabaseContext.SaveChangesAsync();
        }
    }
}
