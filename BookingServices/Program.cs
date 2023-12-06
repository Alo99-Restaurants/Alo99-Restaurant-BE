using BookingServices.Configs.Injection;
using BookingServices.Core.MiddleWares.ErrorHandler;
using BookingServices.Entities.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using static BookingServices.Core.Models.AppConfigurations;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

//Get all DLL files in the directory
string assemblyDirectory = AppDomain.CurrentDomain.BaseDirectory;
string[] dllFiles = Directory.GetFiles(assemblyDirectory, "BookingServices*.dll");
var assemblies = dllFiles.Select(x => Assembly.LoadFrom(x)).ToArray();

// Add configuration
builder.Services.Configure<JwtConfigurations>(configuration.GetSection("JwtConfigurations"));

// Add services to the container.

builder.Services.AddDbContextConfig(configuration);
builder.Services.AddServices();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddHttpContextAccessor();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));
builder.Services.AddCorsConfig();
builder.Services.AddJsonConfig();
builder.Services.AddAuthenticationConfig(configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();

var app = builder.Build();

//app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Booking Services");
        opt.DisplayRequestDuration();
        //opt.InjectJavascript("/swagger/customAuthorize.js");
    });
}

app.UseCors();

app.UseErrorHandlingMiddleware();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
