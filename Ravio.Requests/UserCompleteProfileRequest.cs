using Ravio.Entities;

namespace Ravio.Requests
{
    public class UserCompleteProfileRequest
    {
        public double Height { get; set; }

        public double Weight { get; set; }

        public double BMI { get; set; }

        public double WaistMessurement { get; set; }

        public double ChestMessurement { get; set; }

        public double HipsMessurement { get; set; }

        public double StomachMessurement { get; set; }

        public double ThighMessurement { get; set; }

        public int LifestyleTypeId { get; set; }
        public virtual LifestyleType Lifestyle { get; set; }

        public int TargetTypeId { get; set; }
        public TargetType Target { get; set; }
    }
}
