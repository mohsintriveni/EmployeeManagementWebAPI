using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagement.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ISecutiryRepository _jwtsecutiry;
        public UserRepository(UserManager<IdentityUser> userManager, ISecutiryRepository jwtsecutiry)
        {
            _userManager = userManager;
            _jwtsecutiry = jwtsecutiry;
        }
        public async Task<UserManagerResponse> RegisterUserAsync(RegisterVM user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("Null Model");
            }

            if (user.Password != user.ConfirmPassword)
            {
                return new UserManagerResponse
                {
                    Message = "Password does not match",
                    IsSuccess = false,
                };
            };

            var newUser = new IdentityUser
            {
                Email = user.Email,
                UserName = user.Email
            };

            var result = await _userManager.CreateAsync(newUser, user.Password);

            if (result.Succeeded)
            {
                var confirmedEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                var encodeEmailToken = Encoding.UTF8.GetBytes(confirmedEmailToken);
                var validEmailToken = WebEncoders.Base64UrlEncode(encodeEmailToken);
            }

            return new UserManagerResponse
            {
                Message = "User Created",
                IsSuccess = true,
            };
        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginVM user)
        {
            var finduser=await _userManager.FindByEmailAsync(user.Email);
            if (finduser == null)
            {
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "User not found"
                };
            }

            var result = await _userManager.CheckPasswordAsync(finduser, user.Password);
            if (!result)
            {
                return new UserManagerResponse
                {
                    Message = "Invalid Password",
                    IsSuccess = false,
                };
            }

            var claims = new[]
            {
                new Claim("Email", user.Email),
                new Claim(ClaimTypes.NameIdentifier, finduser.Id),
            };

            _jwtsecutiry.SecureToken(claims, out JwtSecurityToken token, out string tokenAsString);
            return new UserManagerResponse
            {
                Message = tokenAsString,
                IsSuccess = true,
                ExpiryDate = token.ValidTo
            };


        }
    }
}
