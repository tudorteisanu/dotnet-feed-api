using System;
using feedApi.Users;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using feedApi.Shared.Helpers;

namespace feedApi.Shared.Services.Jwt
{
    public static class JwtService
    {
        public static string GenerateToken(IEnumerable<Claim> claims, DateTime? expires)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(ApplicationSettings.JwtOptions.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                ApplicationSettings.JwtOptions.Issuer,
                ApplicationSettings.JwtOptions.Audience,
                expires: expires != null ? expires : DateTime.Now.AddDays(1),
                claims: claims,
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}

