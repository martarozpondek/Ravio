using Microsoft.AspNetCore.Identity;
using Ravio.Entities;
using Ravio.Requests;
using Ravio.Responses;
using Ravio.WebAPI.Managers;
using Ravio.WebAPI.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Services
{
    public interface IUsersService
    {
        Task<UserSignInResponse> SignInAsync(UserSignInRequest request);

        Task<UserSignUpResponse> SignUpAsync(UserSignUpRequest request);

        Task<UserCompleteProfileResponse> CompleteProfileAsync(UserCompleteProfileRequest request);

        Task<UserSignDownResponse> SignDownAsync(UserSignDownRequest request);
    }

    public class UsersService : IUsersService
    {
        public UsersService(UserManager<UserEntity> userManager, IJwtBearerTokenManager jwtBearerTokenManager, IBodiesMessurementsRepository bodiesMessurementsRepository, DatabaseContext databaseContext)
        {
            UserManager = userManager;
            JwtBearerTokenManager = jwtBearerTokenManager;
            BodiesMessurementsRepository = bodiesMessurementsRepository;
            DatabaseContext = databaseContext;
        }

        private UserManager<UserEntity> UserManager { get; }
        private IJwtBearerTokenManager JwtBearerTokenManager { get; }
        private IBodiesMessurementsRepository BodiesMessurementsRepository { get; }
        private DatabaseContext DatabaseContext { get; }

        public async Task<UserSignInResponse> SignInAsync(UserSignInRequest request)
        {
            var result = await UserManager.CheckPasswordAsync(await UserManager.FindByNameAsync(request.UserName), request.Password);
            
            if (result)
            {
                var user = await UserManager.FindByNameAsync(request.UserName);
                return new UserSignInResponse(true, "", JwtBearerTokenManager.Encode(user.Id, user.UserName, user.Email));
            }
            else
            {
                return new UserSignInResponse(false, "Bad credentials.");
            }
        }

        public async Task<UserSignUpResponse> SignUpAsync(UserSignUpRequest request)
        {
            var result = await UserManager.CreateAsync(new UserEntity(request.UserName) { Email = request.Email, PhoneNumber = request.PhoneNumber, BirthDate = request.BirthDate, Gender = request.Gender }, request.Password);

            if (result.Succeeded)
            {
                var user = await UserManager.FindByNameAsync(request.UserName);
                return new UserSignUpResponse(true, "", JwtBearerTokenManager.Encode(user.Id, user.UserName, user.Email));
            }
            else
            {
                return new UserSignUpResponse(false, result.Errors.ToList()[0].Description);
            }
        }

        public async Task<UserCompleteProfileResponse> CompleteProfileAsync(UserCompleteProfileRequest request)
        {
            var user = await DatabaseContext.Accounts.FindAsync(request.UserId);
            if (user == null) return new UserCompleteProfileResponse(false, "User not found");
            user.Lifestyle = request.Lifestyle;
            user.Target = request.Target;

            await BodiesMessurementsRepository.PostBodyMessurement(request.BodyMessurements);

            return new UserCompleteProfileResponse(true, "");
        }

        public async Task<UserSignDownResponse> SignDownAsync(UserSignDownRequest request)
        {
            var result = await UserManager.DeleteAsync(await UserManager.FindByNameAsync(request.UserName));

            if (result.Succeeded)
            {
                return new UserSignDownResponse(true);
            }
            else return new UserSignDownResponse(false, result.Errors.ToList()[0].Description);
        }
    }
}
