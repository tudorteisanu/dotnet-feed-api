namespace ErrorManagement.Configurations;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder ConfigureApplication(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalErrorHandlingMiddleware>();

        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();


        return app;
    }
}