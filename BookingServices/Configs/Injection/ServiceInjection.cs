﻿using BookingServices.Application.Services.Booking;
using BookingServices.Application.Services.Customer;
using BookingServices.Application.Services.Restaurant;
using BookingServices.Application.Services.RestaurantFloor;
using BookingServices.Application.Services.RestaurantImage;
using BookingServices.Application.Services.Table;
using BookingServices.Application.Services.User;
using BookingServices.Core.Redis;
using BookingServices.Entities.Contexts;
using BookingServices.External.Interfaces;
using BookingServices.External.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        services.AddScoped<IRestaurantServices, RestaurantServices>();
        services.AddScoped<IRestaurantFloorServices, RestaurantFloorServices>();
        services.AddScoped<ITableServices, TableServices>();
        services.AddScoped<IUserServices, UserServices>();
        services.AddScoped<ICustomerServices, CustomerServices>();
        services.AddScoped<IRestaurantImageServices, RestaurantImageServices>();
        services.AddScoped<IBookingServices, BookingServices.Application.Services.Booking.BookingServices>();

        //external services
        //services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IAwsS3Services, AwsS3Service>();
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
            options.AddDefaultPolicy(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());   
            options.AddPolicy("AllowSwagger", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .WithExposedHeaders("Content-Disposition");

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
        }).AddNewtonsoftJson(options =>
        {
            // Configure JSON serialization settings here for Newtonsoft.Json
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            // Add the StringEnumConverter to handle enums as strings
            options.SerializerSettings.Converters.Add(new StringEnumConverter());
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

    //add google authentication
    public static IServiceCollection AddGoogleAuthenticationConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            //options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
        })
        .AddCookie(opt =>
        {
            opt.LoginPath = "/api/User/google-auth";
        }).AddGoogle(options =>
        {
            var google = configuration.GetSection("GoogleConfigurations").Get<GoogleConfigurations>();
            options.ClientId = google?.ClientId ?? throw new ArgumentNullException();
            options.ClientSecret = google?.ClientSecret ?? throw new ArgumentNullException();
            options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.SaveTokens = true;
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
            return new RedisService(redis?.ConnectionString ?? throw new ArgumentNullException(), options => { });
        });
        return services;
    }

}
