using feedApi.AppDbContextNS;
using Microsoft.OpenApi.Models;

using Microsoft.EntityFrameworkCore;

namespace ServicesExtensions;

public static class ServicesExtensions
{
    public static IServiceCollection ConfigureAppServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
        });
   
        services.AddControllers();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddDbContext<AppDbContext>(options =>
                            options.UseNpgsql(config.GetConnectionString("Postgres")));
        return services;
    }
}