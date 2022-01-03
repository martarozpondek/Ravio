using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ravio.Entities
{
    public class BodyMessurementsEntity
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        [NotMapped]
        public double BMI { get { return  Math.Round(Weight / ((Height / 100) * (Height / 100)), 2); } }

        public double WaistMessurement { get; set; }

        public double ChestMessurement { get; set; }

        public double HipsMessurement { get; set; }

        public double StomachMessurement { get; set; }

        public double ThighMessurement { get; set; }

        public int? UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
