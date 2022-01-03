namespace Ravio.Responses
{
    public class UserSignDownResponse
    {
        public UserSignDownResponse()
        {

        }
        public UserSignDownResponse(bool isSucceeded)
        {
            IsSucceeded = isSucceeded;
        }

        public UserSignDownResponse(bool isSucceeded, string error)
        {
            IsSucceeded = isSucceeded;
            Error = error;
        }

        public bool IsSucceeded { get; set; }

        public string Error { get; set; }
    }
}
