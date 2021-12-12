using Ravio.Entities;

namespace Ravio.Requests
{
    public class UserCompleteProfileRequest
    {
        public int UserId { get; set; }

        public virtual LifestyleType Lifestyle { get; set; }

        public virtual TargetType Target { get; set; }

        public BodyMessurementsEntity BodyMessurements { get; set; }
    }
}
