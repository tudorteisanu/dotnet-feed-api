using feedApi.Auth;
using feedApi.Roles;
using feedApi.Users;

namespace DIExtensions;

public static class DIExtensions
{
    public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IRoleService, RoleService>();

        return services;
    }
}