using Microsoft.AspNetCore.Mvc;
using Ravio.Entities;
using Ravio.WebAPI.Repositories;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        public NewsController(INewsRepository newsRepository)
        {
            NewsRepository = newsRepository;
        }

        private INewsRepository NewsRepository { get; }

        [HttpGet]
        public async Task<ActionResult<NewsEntity>> GetNews()
        {
            return await NewsRepository.GetNews();
        }
    }
}
