using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ravio.Entities;
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
            var response = await UsersService.SignInAsync(request);

            if (response.IsSucceeded) return Ok(response);
            else return BadRequest(response);
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult<UserSignUpResponse>> SignUpAsync(UserSignUpRequest request)
        {
            var response = await UsersService.SignUpAsync(request);

            if (response.IsSucceeded) return Ok(response);
            else return BadRequest(response);
        }

        [HttpPost("CompleteProfile")]
        public async Task<ActionResult<UserCompleteProfileResponse>> CompleteProfile(UserCompleteProfileRequest request)
        {
            var response = await UsersService.CompleteProfileAsync(request, User.Identity.Name);

            if (response.IsSucceeded) return Ok(response);
            else return BadRequest(response);
        }

        [HttpPost("SignDown")]
        public async Task<ActionResult<UserSignInResponse>> SignDownAsync()
        {
            var response = await UsersService.SignDownAsync(new UserSignDownRequest(User.Identity.Name));

            if (response.IsSucceeded) return Ok(response);
            else return BadRequest(response);
        }

        [HttpGet]
        public async Task<ActionResult<UserEntity>> GetUserByUserName()
        {
            return await UsersService.GetUserByUserName(User.Identity.Name);
        }
    }
}
