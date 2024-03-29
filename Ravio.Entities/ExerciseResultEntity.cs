﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ravio.Entities
{
    public class ExerciseResultEntity
    {
        public int Id { get; set; }

        public int? NumberOfRepetitions { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        [NotMapped]
        [JsonIgnore]
        public TimeSpan? Time { get { return EndTime - StartTime; } set { } }

        [NotMapped]
        [JsonIgnore]
        public int? Calories { get { return NumberOfRepetitions * Exercise.BurningParameter; } set { }  }

        public int? ExerciseId { get; set; }
        public virtual ExerciseEntity Exercise { get; set; }

        public int? UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
