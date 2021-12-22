using System;

namespace Ravio.Entities
{
    public class ExerciseResultEntity
    {
        public int Id { get; set; }

        public int? NumberOfRepetitions { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public TimeSpan? Time { get; set; }

        public int? Calories { get; set; }

        public int? ExerciseId { get; set; }
        public virtual ExerciseEntity Exercise { get; set; }

        public int? UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
