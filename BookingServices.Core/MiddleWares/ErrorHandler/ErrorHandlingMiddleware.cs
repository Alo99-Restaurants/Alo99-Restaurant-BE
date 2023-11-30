using BookingServices.Core.Models.ControllerResponse;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BookingServices.Core.MiddleWares.ErrorHandler
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ClientException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

                var apiResult = new ApiResult { Message = ex.Message, Code = ex.Code ?? "ERROR" };
                // You can customize the response here
                context.Response.StatusCode = 400; // Internal Server Error
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(apiResult));
            }
            catch (Exception ex)
            {
                // Log the exception (you can replace this with your logging mechanism)
                Console.WriteLine($"An error occurred: {ex.Message}");

                // Create an ApiResult with an error message
                var apiResult = new ApiResult { Message = ex.Message, Code = "SERVER ERROR" };

                // Serialize the ApiResult to JSON and write it to the response
                context.Response.StatusCode = 500; // Internal Server Error
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(apiResult));
            }
        }
    }
}
