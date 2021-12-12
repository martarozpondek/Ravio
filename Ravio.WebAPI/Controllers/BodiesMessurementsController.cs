using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ravio.Entities;
using Ravio.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Controllers
{

    [Route("[Controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class BodiesMessurementsController : ControllerBase
    {
        public BodiesMessurementsController(IBodiesMessuerementsService bodiesMessurementsService)
        {
            BodiesMessurementsService = bodiesMessurementsService;
        }

        private IBodiesMessuerementsService BodiesMessurementsService { get; }

        [HttpGet]
        public async Task<List<BodyMessurementsEntity>> GetBodyMessurementsByUserName()
        {
            return await BodiesMessurementsService.GetBodyMessurementsByUserName(User.Identity.Name);
        }
        [HttpGet]
        public async Task<BodyMessurementsEntity> GetLastBodyMessurementsByUserName()
        {
            return await BodiesMessurementsService.GetLastBodyMessurementsByUserName(User.Identity.Name);
        }

        [HttpPost]
        public async Task PostBodyMessurementsByUserName(BodyMessurementsEntity bodyMessurements)
        {
            await BodiesMessurementsService.PostBodyMessurementsByUserName(bodyMessurements, User.Identity.Name);
        }
    }
}