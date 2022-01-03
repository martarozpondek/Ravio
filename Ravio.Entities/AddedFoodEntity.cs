using System;
using System.Collections.Generic;
using System.Text;

namespace Ravio.Entities
{
    public class AddedFoodEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Calories { get; set; }

        public int Grams { get; set; }

        public FoodType Type { get; set; }

        public int? FoodResultId { get; set; }
        public virtual FoodResultEntity FoodResult { get; set; }
    }

    public enum FoodType
    {
        Breakfast, Lunch, Dinner, Supper, Snacks
    }
}
