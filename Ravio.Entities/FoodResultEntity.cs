using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Ravio.Entities
{
    public class FoodResultEntity
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [NotMapped]
        public int? Calories
        {
            get
            {
                if (AddedFood == null || !AddedFood.Any())
                {
                    return 0;
                }

                else return AddedFood.Select(food => food.Calories).Sum();

            }
            set { }
        }

        public int TargetCalories { get; set; }

        public virtual List<AddedFoodEntity> AddedFood { get; set; }

        public int? UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
