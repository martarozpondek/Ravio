using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ravio.Entities
{
    public class WorkoutResultEntity
    {
        public int Id { get; set; }

        public double Distance { get; set; }

        public double AverageSpeed { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [NotMapped]
        public TimeSpan Time { get { return EndTime - StartTime; } set { } }

        [NotMapped]
        public int Calories { get { return Convert.ToInt32(Time.TotalMinutes * Workout.BurningParameter); } set { } }

        public ICollection<CoordinatesEntity> Coordinates { get; set; }

        public int? WorkoutId { get; set; }
        public virtual WorkoutEntity Workout { get; set; }

        public int? UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
