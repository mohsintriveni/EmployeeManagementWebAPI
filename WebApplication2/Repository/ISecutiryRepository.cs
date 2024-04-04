using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EmployeeManagement.Repository
{
    public interface ISecutiryRepository
    {
        void SecureToken(Claim[] claim, out JwtSecurityToken token, out string tokenAsString);
    }
}
