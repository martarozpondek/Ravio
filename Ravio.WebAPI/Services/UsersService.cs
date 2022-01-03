using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ravio.Entities;
using Ravio.Requests;
using Ravio.Responses;
using Ravio.WebAPI.Managers;
using Ravio.WebAPI.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Services
{
    public interface IUsersService
    {
        Task<UserSignInResponse> SignInAsync(UserSignInRequest request);

        Task<UserSignUpResponse> SignUpAsync(UserSignUpRequest request);

        Task<UserCompleteProfileResponse> CompleteProfileAsync(UserCompleteProfileRequest request, string userName);

        Task<UserSignDownResponse> SignDownAsync(UserSignDownRequest request);

        Task<UserEntity> GetUserByUserName(string userName);
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
            var result = await UserManager.CreateAsync(new UserEntity(request.UserName) { Email = request.Email, PhoneNumber = request.PhoneNumber, BirthDate = request.BirthDate, GenderTypeId = request.Gender.Id }, request.Password);

            if (result.Succeeded)
            {
                var user = await DatabaseContext.Accounts.Include(user => user.Gender).Include(user => user.Lifestyle).FirstOrDefaultAsync(user => user.UserName == request.UserName);
                return new UserSignUpResponse(true, "", JwtBearerTokenManager.Encode(user.Id, user.UserName, user.Email), user.Age, user.Gender.Name);
            }
            else
            {
                return new UserSignUpResponse(false, result.Errors.ToList()[0].Description);
            }
        }

        public async Task<UserCompleteProfileResponse> CompleteProfileAsync(UserCompleteProfileRequest request, string userName)
        {
            var user = await DatabaseContext.Accounts.FirstOrDefaultAsync(user => user.UserName == userName);
            if (user == null) return new UserCompleteProfileResponse(false, "User not found");
            user.LifestyleTypeId = request.Lifestyle.Id;
            user.TargetTypeId = request.Target.Id;
            await DatabaseContext.SaveChangesAsync();


            await BodiesMessurementsRepository.PostBodyMessurementsByUserName(new BodyMessurementsEntity() { User = user, Date = DateTime.Now, Weight = request.Weight, Height = request.Height, WaistMessurement = request.WaistMessurement, ChestMessurement = request.ChestMessurement, HipsMessurement = request.HipsMessurement, StomachMessurement = request.StomachMessurement, ThighMessurement = request.ThighMessurement }, userName);

            return new UserCompleteProfileResponse(true, "", user.Target);
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

        public async Task<UserEntity> GetUserByUserName(string userName)
        {
            return await DatabaseContext.Accounts.Include(account => account.Gender).FirstOrDefaultAsync(account => account.UserName == userName);
        }
    }
}
