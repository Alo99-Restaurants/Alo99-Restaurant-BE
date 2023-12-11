using BookingServices.Core.Models.ControllerResponse;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;

namespace BookingServices.Configs.Exceptions;

public class ExceptionHandler : IExceptionHandler
{
    private readonly ILogger<ExceptionHandler> _logger;

    public ExceptionHandler(ILogger<ExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        (int statusCode, string message) = exception switch
        {
            ClientException clientException => (400, clientException.Message),
            _ => (500, "Internal Server Error")
        };

        _logger.LogError(exception, exception.Message);
        httpContext.Response.StatusCode = statusCode;
        httpContext.Response.ContentType = "application/json";
        await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new ApiResult {Code = "ERROR" ,Message = message }));

        return true;
    }
}
