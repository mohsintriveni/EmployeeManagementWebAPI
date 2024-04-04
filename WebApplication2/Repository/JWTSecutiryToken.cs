using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagement.Repository
{
    public class JWTSecutiryToken : ISecutiryRepository
    {
        public IConfiguration _configuration;
        public JWTSecutiryToken(IConfiguration configuration)
        {
            _configuration = configuration;   
        }
        public void SecureToken(Claim[] claim, out JwtSecurityToken token, out string tokenAsString)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:Key"]));
            token = new JwtSecurityToken
            (
                issuer: _configuration["Authentication:Issuer"],
                audience: _configuration["Authentication:Audience"],
                claims: claim,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            
        }
    }
}
