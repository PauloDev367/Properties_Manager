using Api.Middlewares;

namespace Api.Extensions;

public static class ExceptionMiddlewareExtension
{

    public static void ConfigureGlobalExceptionHandler(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }

}
