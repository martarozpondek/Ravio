using Ravio.Entities;
using Ravio.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ravio.Services
{
    public class AwardsService
    {
        private AwardsRepository AwardsRepository => DependencyService.Get<AwardsRepository>();

        public async Task<List<AwardEntity>> GetWorkoutsAwardsByUserName()
        {
            return await AwardsRepository.GetAwardsForWorkouts();
        }

        public async Task<List<AwardEntity>> GetExercisesAwardsByUserName()
        {
            return await AwardsRepository.GetAwardsForExercises();
        }

        public async Task<List<AwardEntity>> GetFoodAwardsByUserName()
        {
            return await AwardsRepository.GetAwardsForFood();
        }

        public async Task PostAward(AwardEntity award)
        {
            await AwardsRepository.PostAward(award);
        }

        public async Task CheckWorkoutAward()
        {
            await AwardsRepository.CheckWorkoutsAward();
        }

        public async Task CheckExerciseAward()
        {
            await AwardsRepository.CheckExercisesAward();
        }

        public async Task CheckFoodAward()
        {
            await AwardsRepository.CheckFoodAward();
        }
    }
}
