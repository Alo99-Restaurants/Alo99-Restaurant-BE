using BookingServices.Application.Services.Restaurant;
using BookingServices.Application.Services.RestaurantFloor;
using BookingServices.Application.Services.Table;
using BookingServices.Application.Services.User;

namespace BookingServices.Configs.Injection;

public static class ServiceInjection
{
    public static IServiceCollection AddServiceInjection(this IServiceCollection services)
    {
        services.AddScoped<IRestaurantServices, RestaurantServices>();
        services.AddScoped<IRestaurantFloorServices, RestaurantFloorServices>();
        services.AddScoped<ITableServices, TableServices>();
        services.AddScoped<IUserServices, UserServices>();

        return services;
    }
}
