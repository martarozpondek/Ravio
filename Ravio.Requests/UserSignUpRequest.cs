using Ravio.Entities;
using System;

namespace Ravio.Requests
{
    public class UserSignUpRequest
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public int? GenderTypeId { get; set; }
        public virtual GenderType Gender { get; set; }
    }
}
