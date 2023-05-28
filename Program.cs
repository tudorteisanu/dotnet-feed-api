using System.Configuration;

using SwaggerExtensions;
using DIExtensions;
using ServicesExtensions;
using feedApi.Shared.Helpers;
using ErrorManagement.Configurations;
using JwtExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.GetSection(ApplicationSettings.Jwt).Bind(ApplicationSettings.JwtOptions);
builder.Services.ConfigureAppServices(builder.Configuration);
builder.Services.AddDIServices(builder.Configuration);
builder.Services.AddJwtConfig();

var app = builder.Build();

app.ConfigureApplication();

app.MapControllers();
app.UseSwagger();
app.Run();

