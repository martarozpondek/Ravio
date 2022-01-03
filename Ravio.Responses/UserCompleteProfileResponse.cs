using Ravio.Entities;

namespace Ravio.Responses
{
    public class UserCompleteProfileResponse
    {
        public UserCompleteProfileResponse()
        {

        }
        public UserCompleteProfileResponse(bool isSucceeded, string error)
        {
            IsSucceeded = isSucceeded;
            Error = error;
        }

        public UserCompleteProfileResponse(bool isSucceeded, string error, TargetType target)
        {
            IsSucceeded = isSucceeded;
            Error = error;
            Target = target;
        }

        public bool IsSucceeded { get; set; }

        public string Error { get; set; }

        public TargetType Target { get; set; }
    }
}
