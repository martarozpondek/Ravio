﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Ravio.Entities
{
    public class FoodResultEntity
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Calories { get { return AddedFood.Select(food => food.Calories).Sum(); } }

        public int TargetCalories { get; set; }

        public virtual List<AddedFoodEntity> AddedFood { get; set; }

        public int? UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
