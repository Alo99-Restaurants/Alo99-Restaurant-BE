using BookingServices.Configs.Injection;
using BookingServices.Core.MiddleWares.ErrorHandler;
using Hangfire;
using HangfireBasicAuthenticationFilter;
using Microsoft.AspNetCore.HttpOverrides;
using System.Reflection;
using static AppConfigurations;

//Script-Migration
var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

//Get all DLL files in the directory
string assemblyDirectory = AppDomain.CurrentDomain.BaseDirectory;
string[] dllFiles = Directory.GetFiles(assemblyDirectory, "BookingServices*.dll");
var assemblies = dllFiles.Select(x => Assembly.LoadFrom(x)).ToArray();

// Add configuration
builder.Services.Configure<JwtConfigurations>(configuration.GetSection("JwtConfigurations"));
builder.Services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
builder.Services.Configure<AWSS3Configurations>(configuration.GetSection("AWSS3"));
builder.Services.Configure<EmailConfigurations>(configuration.GetSection("EmailConfigurations"));
builder.Services.Configure<VnPayConfigs>(configuration.GetSection("VnPayConfigs"));

// Add services to the container.

builder.Services.AddDbContextConfig(configuration);
builder.Services.AddRedisConfig(configuration);
builder.Services.AddServices();

builder.Services.AddAutoMapperConfig(assemblies);

builder.Services.AddHttpContextAccessor();
builder.Services.AddMediatRConfig(assemblies);
builder.Services.AddCorsConfig();
builder.Services.AddJsonConfig();
builder.Services.AddAuthenticationConfig(configuration);
builder.Services.AddGoogleAuthenticationConfig(configuration);
builder.Services.AddHangfireConfig(configuration);

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

//builder.Services.AddExceptionHandler<ExceptionHandler>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();

var app = builder.Build();

app.UseForwardedHeaders();

app.UseCors(builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
);

app.UseSwagger();
app.UseSwaggerUI(opt =>
{
    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Booking Services");
    opt.DisplayRequestDuration();
});

app.UseHttpsRedirection();
app.UseErrorHandlingMiddleware();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseHangfireDashboard("/hangfire", new DashboardOptions()
{
    DashboardTitle = "Booking Services Hangfire Dashboard",
    Authorization = new[] { new HangfireCustomBasicAuthenticationFilter { 
        User = "admin",
        Pass = "admin"
    } }
    
});
app.Run();


