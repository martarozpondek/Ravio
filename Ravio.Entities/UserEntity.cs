using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Ravio.Entities
{
    public class UserEntity : IdentityUser<int>
    {
        public UserEntity() : base()
        {

        }

        public UserEntity(string userName) : base(userName)
        {

        }

        public DateTime BirthDate { get; set; }

        public int? GenderTypeId { get; set; }
        public virtual GenderType Gender { get; set; }

        public int? LifestyleTypeId { get; set; }
        public virtual LifestyleType Lifestyle { get; set; }

        public int? TargetTypeId { get; set; }
        public virtual TargetType Target { get; set; }

        public virtual ICollection<BodyMessurementsEntity> BodyMessurements { get; set; }

        public virtual ICollection<WorkoutResultEntity> WorkoutsResults { get; set; }
        public virtual ICollection<ExerciseResultEntity> ExercisesResults { get; set; }
        public virtual ICollection<FoodResultEntity> FoodResults { get; set; }

        public virtual ICollection<AwardEntity> Awards { get; set; }
    }

    public class GenderType
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class LifestyleType
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class TargetType
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
