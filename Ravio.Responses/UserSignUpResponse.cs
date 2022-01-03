using Ravio.Entities;

namespace Ravio.Responses
{
    public class UserSignUpResponse
    {
        public UserSignUpResponse()
        {

        }

        public UserSignUpResponse(bool isSucceeded, string error)
        {
            IsSucceeded = isSucceeded;
            Error = error;
        }

        public UserSignUpResponse(bool isSucceeded, string error, string token, int age, string genderName)
        {
            IsSucceeded = isSucceeded;
            Error = error;
            Token = token;
            Age = age;
            GenderName = genderName;
        }

        public bool IsSucceeded { get; set; }

        public string Error { get; set; }

        public string Token { get; set; }

        public int Age { get; set; }

        public string GenderName { get; set; }
    }
}
