using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ravio.WebAPI.Services;

namespace Ravio.WebAPI.Controllers
{
    [Route("[Controller]")]
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class WorkoutsResultsController : ControllerBase
    {
        public WorkoutsResultsController(IWorkoutsResultsService workoutsResultsService)
        {
            WorkoutsResultsService = workoutsResultsService;
        }

        private IWorkoutsResultsService WorkoutsResultsService { get; }
    }
}
