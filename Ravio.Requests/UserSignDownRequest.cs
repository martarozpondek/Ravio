namespace Ravio.Requests
{
    public class UserSignDownRequest
    {
        public UserSignDownRequest()
        {

        }

        public UserSignDownRequest(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }
    }
}
