﻿using Ravio.Entities;

namespace Ravio.Responses
{
    public class UserSignUpResponse
    {
        public UserSignUpResponse(bool isSucceeded, string error)
        {
            IsSucceeded = isSucceeded;
            Error = error;
        }

        public UserSignUpResponse(bool isSucceeded, string error, string token, int age, GenderType gender, LifestyleType lifestyle)
        {
            IsSucceeded = isSucceeded;
            Error = error;
            Token = token;
            Age = age;
            Gender = gender;
            Lifestyle = lifestyle;
        }

        public bool IsSucceeded { get; set; }

        public string Error { get; set; }

        public string Token { get; set; }

        public int Age { get; set; }

        public GenderType Gender { get; set; }

        public LifestyleType Lifestyle { get; set; }
    }
}
