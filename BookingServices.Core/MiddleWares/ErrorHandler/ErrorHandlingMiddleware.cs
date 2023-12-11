using BookingServices.Core.Models.ControllerResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BookingServices.Core.MiddleWares.ErrorHandler;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ClientException ex)
        {
            //log endpoint

            _logger.LogError(ex,$"{context.Request.Method} {context.Request.GetDisplayUrl()}");

            var apiResult = new ApiResult { Message = ex.Message, Code = ex.Code ?? "ERROR" };
            // You can customize the response here
            context.Response.StatusCode = 400; // Internal Server Error
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(apiResult));
        }
        catch (Exception ex)
        {
            // Log the exception (you can replace this with your logging mechanism)
            _logger.LogError(ex, $"{context.Request.Method} {context.Request.Method} {context.Request.GetDisplayUrl()}");

            // Create an ApiResult with an error message
            var apiResult = new ApiResult { Message = ex.Message, Code = "SERVER ERROR" };

            // Serialize the ApiResult to JSON and write it to the response
            context.Response.StatusCode = 500; // Internal Server Error
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(apiResult));
        }
      
    }
}
