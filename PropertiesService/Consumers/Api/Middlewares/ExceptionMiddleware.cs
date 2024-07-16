using Api.ViewModels;
using Application.ApplicationExceptions;
using Domain.DomainExceptions;

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
        catch (PropertyPriceNotAllowedException ex)
        {
            errorDetail.Message = ex.Message;
            errorDetail.StatusCode = 400;
            await WriteHttpResponseAsync(errorDetail, httpContext);
        }
        catch (PropertyNotFoundException ex)
        {
            errorDetail.Message = ex.Message;
            errorDetail.StatusCode = 404;
            await WriteHttpResponseAsync(errorDetail, httpContext);
        }
        catch (UserNotFoundException ex)
        {
            errorDetail.Message = ex.Message;
            errorDetail.StatusCode = 404;
            await WriteHttpResponseAsync(errorDetail, httpContext);
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
