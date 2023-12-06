using BookingServices.Application.Services.Restaurant;
using BookingServices.Application.Services.RestaurantFloor;
using BookingServices.Application.Services.Table;
using BookingServices.Application.Services.User;
using BookingServices.Entities.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;
using static BookingServices.Core.Models.AppConfigurations;

namespace BookingServices.Configs.Injection;

public static class ServiceInjection
{
    //services
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IRestaurantServices, RestaurantServices>();
        services.AddScoped<IRestaurantFloorServices, RestaurantFloorServices>();
        services.AddScoped<ITableServices, TableServices>();
        services.AddScoped<IUserServices, UserServices>();

        return services;
    }

    //add dbcontext
    public static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BookingDbContext>(options =>
            options.UseMySql(configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")))
#if DEBUG
            .EnableSensitiveDataLogging().EnableDetailedErrors()
#endif
            );
        return services;
    }

    //add cors
    public static IServiceCollection AddCorsConfig(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyHeader().WithExposedHeaders("Content-Disposition", "Api-Supported-Versions").AllowAnyMethod();
            });
        });
        return services;
    }

    //json config
    public static IServiceCollection AddJsonConfig(this IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });
        return services;
    }

    //add authentication
    public static IServiceCollection AddAuthenticationConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            var jwt = configuration.GetSection("JwtConfigurations").Get<JwtConfigurations>();
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwt?.Issuer, // Replace with your issuer
                ValidAudience = jwt?.Audience, // Replace with your audience
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt?.SecretKey ?? throw new ArgumentNullException())) // Replace with your secret key
            };
        });
        return services;
    }

    //add swagger
    public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Booking Services", Version = "v1" });
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

        });
        return services;
    }

}
