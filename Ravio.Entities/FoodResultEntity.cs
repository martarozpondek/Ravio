using System;
using System.Collections.Generic;

namespace Ravio.Entities
{
    public class FoodResultEntity
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Calories { get; set; }

        public int TargetCalories { get; set; }

        public virtual List<FoodEntity> Foods { get; set; }

        public int? UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }

    public enum FoodType
    {
        Breakfast, Lunch, Dinner, Supper, Snacks
    }
}
