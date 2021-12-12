using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ravio.WebAPI.Managers
{
    public interface IJwtBearerTokenManager
    {
        string Encode(int id, string userName, string email);
    }

    public class JwtBearerTokenManager : IJwtBearerTokenManager
    {
        public JwtBearerTokenManager(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public string Encode(int id, string userName, string email)
        {
            JwtSecurityTokenHandler TokenHandler = new JwtSecurityTokenHandler();
            return TokenHandler.WriteToken(TokenHandler.CreateToken(new SecurityTokenDescriptor() { SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("Key"))), SecurityAlgorithms.HmacSha256), Subject = new ClaimsIdentity(new[] { new Claim("Id", id.ToString()), new Claim(ClaimTypes.Name, userName), new Claim(ClaimTypes.Email, email) }) }));
        }
    }
}
