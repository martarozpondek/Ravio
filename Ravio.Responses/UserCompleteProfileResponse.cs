namespace Ravio.Responses
{
    public class UserCompleteProfileResponse
    {
        public UserCompleteProfileResponse(bool isSucceeded, string error)
        {
            IsSucceeded = isSucceeded;
            Error = error;
        }

        public bool IsSucceeded { get; set; }

        public string Error { get; set; }
    }
}
