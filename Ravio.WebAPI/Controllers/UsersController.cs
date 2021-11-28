using Microsoft.AspNetCore.Mvc;
using Ravio.Requests;
using Ravio.Responses;
using Ravio.WebAPI.Services;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController(IUsersService usersService)
        {
            UsersService = usersService;
        }

        private IUsersService UsersService { get; }

        [HttpPost("SignIn")]
        public async Task<ActionResult<UserSignInResponse>> SignInAsync(UserSignInRequest request)
        {
            return Ok();
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult<UserSignUpResponse>> SignUpAsync(UserSignUpRequest request)
        {
            return Ok();
        }

        [HttpPost("SignDown")]
        public async Task<ActionResult<UserSignInResponse>> SignDownAsync()
        {
            return Ok();
        }
    }
}
