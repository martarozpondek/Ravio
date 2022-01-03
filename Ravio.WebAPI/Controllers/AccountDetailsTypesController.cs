using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ravio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class AccountDetailsTypesController : ControllerBase
    {
        private DatabaseContext DatabaseContext { get;  }

        public AccountDetailsTypesController(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        [HttpGet("Genders")]
        public async Task<List<GenderType>> GetGenderTypes()
        {
            return await DatabaseContext.GenderTypes.ToListAsync();
        }

        [HttpGet("Lifestyles")]
        public async Task<List<LifestyleType>> GetLifestyleTypes()
        {
            return await DatabaseContext.LifestyleTypes.ToListAsync();
        }

        [HttpGet("Targets")]
        public async Task<List<TargetType>> GetTargetTypes()
        {
            return await DatabaseContext.TargetTypes.ToListAsync();
        }
    }
}
