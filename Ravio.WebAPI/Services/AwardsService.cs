using Ravio.Entities;
using Ravio.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravio.WebAPI.Services
{
    public interface IAwardsService
    {
        Task<List<AwardEntity>> GetWorkoutsAwardsByUserName(string userName);

        Task<List<AwardEntity>> GetExercisesAwardsByUserName(string userName);

        Task<List<AwardEntity>> GetFoodAwardsByUserName(string userName);

        Task PostAwardByUserName(AwardEntity award, string userName);

        Task LevelUpExerciseAward(string userName);

        Task LevelUpWorkoutAward(string userName);

        Task LevelUpFoodAward(string userName);

        Task CloseExerciseAward(string userName);

        Task CloseWorkoutAward(string userName);

        Task CloseFoodAward(string userName);
    }

    public class AwardsService : IAwardsService
    {
        public AwardsService(IAwardsRepository awardsRepository)
        {
            AwardsRepository = awardsRepository;
        }

        private IAwardsRepository AwardsRepository { get; }

        public async Task<List<AwardEntity>> GetWorkoutsAwardsByUserName(string userName)
        {
            return await AwardsRepository.GetWorkoutsAwardsByUserName(userName);
        }

        public async Task<List<AwardEntity>> GetExercisesAwardsByUserName(string userName)
        {
            return await AwardsRepository.GetExercisesAwardsByUserName(userName);
        }

        public async Task<List<AwardEntity>> GetFoodAwardsByUserName(string userName)
        {
            return await AwardsRepository.GetFoodAwardsByUserName(userName);
        }

        public async Task PostAwardByUserName(AwardEntity award, string userName)
        {
            await AwardsRepository.PostAwardByUserName(award, userName);
        }

        public async Task LevelUpWorkoutAward(string userName)
        {
            var awards = await AwardsRepository.GetWorkoutsAwardsByUserName(userName);
            var award = awards.FirstOrDefault(award => award.IsEnabled == true);
            award.Level++;
            await AwardsRepository.PutAward(award);
        }

        public async Task LevelUpExerciseAward(string userName)
        {
            var awards = await AwardsRepository.GetExercisesAwardsByUserName(userName);
            var award = awards.FirstOrDefault(award => award.IsEnabled == true);
            award.Level++;
            await AwardsRepository.PutAward(award);
        }

        public async Task LevelUpFoodAward(string userName)
        {
            var awards = await AwardsRepository.GetFoodAwardsByUserName(userName);
            var award = awards.FirstOrDefault(award => award.IsEnabled == true);
            award.Level++;
            await AwardsRepository.PutAward(award);
        }

        public async Task CloseWorkoutAward(string userName)
        {
            var awards = await AwardsRepository.GetWorkoutsAwardsByUserName(userName);
            var award = awards.FirstOrDefault(award => award.IsEnabled == true);
            award.IsEnabled = false;
            await AwardsRepository.PutAward(award);
        }

        public async Task CloseExerciseAward(string userName)
        {
            var awards = await AwardsRepository.GetExercisesAwardsByUserName(userName);
            var award = awards.FirstOrDefault(award => award.IsEnabled == true);
            award.IsEnabled = false;
            await AwardsRepository.PutAward(award);
        }

        public async Task CloseFoodAward(string userName)
        {
            var awards = await AwardsRepository.GetFoodAwardsByUserName(userName);
            var award = awards.FirstOrDefault(award => award.IsEnabled == true);
            award.IsEnabled =  false;
            await AwardsRepository.PutAward(award);
        }
    }
}
