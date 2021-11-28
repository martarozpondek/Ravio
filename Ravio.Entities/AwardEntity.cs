using System;

namespace Ravio.Entities
{
    public class AwardEntity
    {
        public int Id { get; set; }

        public AwardType Type { get; set; }

        public DateTime Date { get; set; }

        public int Level { get; set; }

        public int? UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }

    public enum AwardType
    {
        Workouts, Exercises, Food
    }
}
