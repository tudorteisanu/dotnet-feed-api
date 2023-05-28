using EntityFramework.Exceptions.Common;
using ErrorManagement.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;


namespace ErrorManagement.Configurations;

public class GlobalErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (DbUpdateException pgException)
        {
            await HandlePostgresExceptionAsync(context, pgException);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.GetType());
            await HandleExceptionAsync(context, ex);

        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode status;
        string stackTrace = null;
        string message;

        var exceptionType = exception.GetType();
        System.Diagnostics.Debug.WriteLine(exceptionType);
        System.Diagnostics.Debug.WriteLine(exception.InnerException);
        if (exceptionType == typeof(BadRequestException))
        {
            message = exception.Message;
            status = HttpStatusCode.BadRequest;
        }
        else if (exceptionType == typeof(NotFoundException))
        {
            message = exception.Message;
            status = HttpStatusCode.NotFound;
        }
        else if (exceptionType == typeof(NotImplementedException))
        {
            status = HttpStatusCode.NotImplemented;
            message = exception.Message;
        }
        else if (exceptionType == typeof(UnauthorizedException))
        {
            status = HttpStatusCode.Unauthorized;
            message = exception.Message;
        }
        else
        {
            status = HttpStatusCode.InternalServerError;
            message = exception.Message;
            stackTrace = exception.StackTrace;
        }

        var exceptionResult = JsonSerializer.Serialize(new { message = message });

        if (stackTrace != null)
        {
            exceptionResult = JsonSerializer.Serialize(new { message = message, stackTrace = stackTrace });
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;

        return context.Response.WriteAsync(exceptionResult);
    }

    private static Task HandlePostgresExceptionAsync(HttpContext context, DbUpdateException exception)
    {
        HttpStatusCode status;
        string stackTrace = null;
        string message;

        var exceptionType = exception.GetType();

        if (exceptionType == typeof(UniqueConstraintException))
        {
            status = HttpStatusCode.Conflict;
            message = "Entity exists on the database";
        } else
        {
            status = HttpStatusCode.InternalServerError;
            message = "Unknown Database error, please contact an administrator";
        }

        var exceptionResult = JsonSerializer.Serialize(new { message = message });

        if (stackTrace != null)
        {
            exceptionResult = JsonSerializer.Serialize(new { message = message, stackTrace = stackTrace });
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;

        return context.Response.WriteAsync(exceptionResult);
    }
}