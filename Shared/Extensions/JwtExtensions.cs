using System.Text;
using ErrorManagement.Configurations;
using feedApi.Shared.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace JwtExtensions;

public static class JwtExtensions
{
    public static IServiceCollection AddJwtConfig(this IServiceCollection services)
    {

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = ApplicationSettings.JwtOptions.Issuer,
                ValidAudience = ApplicationSettings.JwtOptions.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ApplicationSettings.JwtOptions.Key))
            };
        });


        return services;
    }
}