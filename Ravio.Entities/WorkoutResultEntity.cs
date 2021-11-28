using System;

namespace Ravio.Entities
{
    public class WorkoutResultEntity
    {
        public int Id { get; set; }

        public double Distance { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public TimeSpan Time { get; set; }

        public int Calories { get; set; }

        public double AverageSpeed { get; set; }

        public int? WorkoutId { get; set; }
        public virtual WorkoutEntity Workout { get; set; }

        public int? UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
