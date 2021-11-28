namespace Ravio.Responses
{
    public class CompleteProfileResponse
    {
        public CompleteProfileResponse(bool isSucceeded, string error)
        {
            IsSucceeded = isSucceeded;
            Error = error;
        }

        public bool IsSucceeded { get; set; }

        public string Error { get; set; }
    }
}
