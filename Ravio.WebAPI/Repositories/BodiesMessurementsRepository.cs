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

        Task PostBodyMessurementsByUserName(BodyMessurementsEntity bodyMessurements, string userName);
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
            return await DatabaseContext.BodiesMessurements.OrderByDescending(bodyMessurement => bodyMessurement.User.UserName == userName).FirstOrDefaultAsync();
        }

        public async Task PostBodyMessurementsByUserName(BodyMessurementsEntity bodyMessurements, string userName)
        {
            await DatabaseContext.BodiesMessurements.AddAsync(bodyMessurements);
            await DatabaseContext.SaveChangesAsync();
        }
    }
}
