﻿namespace ErrorManagement.Configurations;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder applicationBuilder)
        => applicationBuilder.UseMiddleware<GlobalErrorHandlingMiddleware>();

    public static IApplicationBuilder AddHttpErrorHandler(this IApplicationBuilder applicationBuilder)
        => applicationBuilder.UseMiddleware<HttpErrorHandlingMiddleware>();
}