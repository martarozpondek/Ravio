﻿namespace Ravio.Responses
{
    public class UserSignUpResponse
    {
        public UserSignUpResponse(bool isSucceeded, string error)
        {
            IsSucceeded = isSucceeded;
            Error = error;
        }

        public UserSignUpResponse(bool isSucceeded, string error, string token)
        {
            IsSucceeded = isSucceeded;
            Error = error;
            Token = token;
        }

        public bool IsSucceeded { get; set; }

        public string Error { get; set; }

        public string Token { get; set; }
    }
}