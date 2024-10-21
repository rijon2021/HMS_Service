
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

using DotNet.ApplicationCore.DTOs;


namespace DotNet.Services.Services.Infrastructure
{
    public class TokenService(IConfiguration config) : ITokenService
    {
        public IConfiguration _configuration = config;

        public TokenResult BuildToken(AuthUser user)
        {
            //create claims details based on the user information
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]!),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString()),
                        new Claim("UserId", user.UserID!),
                        new Claim("UserAutoID", user.UserAutoID.ToString()),
                        new Claim("UserTypeID", user.UserTypeID.ToString()),
                        new Claim("OrganizationID", user.OrganizationID.ToString()),
                        new Claim("DesignationID", user.DesignationID.ToString()),
                        new Claim("DepartmentID", user.DepartmentID.ToString()!),
                        new Claim("UserFullName", user.UserFullName!),
                        new Claim("UserRoleID", user.UserRoleID.ToString()),
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(10),
                signingCredentials: signIn
            );

            var tokenResult = new TokenResult
            {
                Access_token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo,
                StatusCode = StatusCodes.Status200OK,
                Message = "Success"
            };

            return tokenResult;
        }
    }
}
