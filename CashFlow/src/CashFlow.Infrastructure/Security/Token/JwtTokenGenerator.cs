using CashFlow.Domain.Entities;
using CashFlow.Domain.Security.Token;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CashFlow.Infrastructure.Security.Token
{
    public class JwtTokenGenerator : IAccessTokenGenerator
    {
        private readonly uint _expirationTimeMinutes;
        private readonly string _singinKey;

        public JwtTokenGenerator(uint expirationTimeMinutes, string singinKey)
        {
            _expirationTimeMinutes = expirationTimeMinutes;
            _singinKey = singinKey;
        }

        public string Generate(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Sid, user.UserIdentifier.ToString()),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(_expirationTimeMinutes),
                SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);

        }

        private SymmetricSecurityKey SecurityKey()
        {
            var key = Encoding.UTF8.GetBytes(_singinKey);

            return new SymmetricSecurityKey(key);
        }
    }
}
