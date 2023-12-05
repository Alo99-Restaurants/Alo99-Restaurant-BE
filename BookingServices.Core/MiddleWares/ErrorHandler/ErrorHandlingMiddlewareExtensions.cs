using Microsoft.AspNetCore.Builder;

namespace BookingServices.Core.MiddleWares.ErrorHandler;

public static class ErrorHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorHandlingMiddleware>();
    }
}
