using BusinessLayer.Service;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using RepositoryLayer.Entity;
using RepositoryLayer.Service;

var logger = NLog.LogManager.Setup().LoadConfigurationFromFile("nlog.config").GetCurrentClassLogger();
logger.Info("Starting Application...");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddSwaggerGen();

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // Add services to the container.

    builder.Services.AddControllers();
    builder.Services.AddScoped<UserRegistrationBL>();
    builder.Services.AddScoped<UserRegistrationRL>();


    var connectionString = builder.Configuration.GetConnectionString("SqlConnection");
    builder.Services.AddDbContext<UserRegistrationContext>(options => options.UseSqlServer(connectionString));


    var app = builder.Build();
    app.UseSwagger();
    app.UseSwaggerUI();

    // Configure the HTTP request pipeline.m,

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch(Exception ex)
{
    logger.Error(ex, "Application stopped due to an exception");
}
finally
{
    NLog.LogManager.Shutdown();
}