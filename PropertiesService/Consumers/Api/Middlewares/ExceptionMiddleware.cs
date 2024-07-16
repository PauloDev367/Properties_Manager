using Api.ViewModels;

namespace Api.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate requestDelegate)
    {
        _next = requestDelegate;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        var errorDetail = new ErrorDetailsVM
        {
            StatusCode = 500,
            Message = "Internal server error",
        };

        try
        {
            await _next(httpContext);
        }
        catch (Exception)
        {
            await WriteHttpResponseAsync(errorDetail, httpContext);
        }
    }

    private async Task WriteHttpResponseAsync(ErrorDetailsVM errorDetail, HttpContext context)
    {
        context.Response.StatusCode = errorDetail.StatusCode;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(errorDetail.ToString());

    }
}
