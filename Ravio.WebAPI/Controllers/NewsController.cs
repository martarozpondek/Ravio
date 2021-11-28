using Microsoft.AspNetCore.Mvc;
using Ravio.WebAPI.Repositories;

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
    }
}
