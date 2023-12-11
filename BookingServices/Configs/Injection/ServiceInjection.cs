using BookingServices.Application.Services.Customer;
using BookingServices.Application.Services.Restaurant;
using BookingServices.Application.Services.RestaurantFloor;
using BookingServices.Application.Services.Table;
using BookingServices.Application.Services.User;
using BookingServices.Core.Redis;
using BookingServices.Entities.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using static AppConfigurations;

namespace BookingServices.Configs.Injection;
/// <summary>
/// config injection if use then add to program.cs
/// </summary>
public static class ServiceInjection
{
    //services
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IRestaurantServices, RestaurantServices>();
        services.AddTransient<IRestaurantFloorServices, RestaurantFloorServices>();
        services.AddTransient<ITableServices, TableServices>();
        services.AddTransient<IUserServices, UserServices>();
        services.AddTransient<ICustomerServices, CustomerServices>();

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

    //add mediatr
    public static IServiceCollection AddMediatRConfig(this IServiceCollection services, Assembly[] assemblies)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));
        return services;
    }
    
    //add automapper
    public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services, Assembly[] assemblies)
    {
        services.AddAutoMapper(assemblies);
        return services;
    }

    //add redis
    public static IServiceCollection AddRedisConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<RedisService>(provider =>
        {
            //bind redis config from appsettings.json into appconfigurations
            var redis = configuration.GetSection("Redis").Get<RedisConfigurations>();
            return new RedisService(redis?.ConnectionString??throw new ArgumentNullException(), options => { });
        });
        return services;
    }

}
