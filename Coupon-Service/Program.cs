
using Coupon.Application;
using Coupon.Infrastructure;
using Coupon_Service.Services;
using Google.Api;
using Google.Cloud.Logging.NLog;
using Microsoft.OpenApi.Models;
using NLog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var logger = LogManager.LoadConfiguration("nlog.xml").GetCurrentClassLogger();

// Log some information. This log entry will be sent to Google Stackdriver Logging.
logger.Info("Coupon Service logs!");

try
{
    // Add services to the container.

    //builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    //builder.Services.AddEndpointsApiExplorer();
   // builder.Services.AddSwaggerGen();
    builder.Services.AddGrpc();
    builder.Services.AddGrpcSwagger();
    //builder.Services.AddGrpcReflection();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1",
          new OpenApiInfo { Title = "gRPC transcoding", Version = "v1" });

        //var filePath = Path.Combine(System.AppContext.BaseDirectory, "Server.xml");
        // c.IncludeXmlComments(filePath);
        // c.IncludeGrpcXmlComments(filePath, includeControllerXmlComments: true);
    });
    builder.Services.AddCouponInfrastructureServices();
    builder.Services.AddCouponApplicationServices();
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    builder.Services.AddAutoMapper(typeof(Coupon_Service.Mapper.Mapping).Assembly);
    builder.Services.AddLoggingServiceV2Client();
    //builder.Services.AddLogging(loggingBuilder =>
    //{
    //    loggingBuilder.ClearProviders();
    //    loggingBuilder.log
    //});

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        //app.UseSwaggerUI(c =>
        //{
        //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        //});
    }

    app.UseHttpsRedirection();

    //app.UseAuthorization();

    //app.MapControllers();

    app.MapGrpcService<CouponSearchService>();
    app.MapGrpcService<CouponSortService>();

    app.Run();
}
catch(Exception exception)
{
    logger.Error(exception, "Stopped coupon service because of exception");
    throw;
}
finally
{

    // Flush buffered log entries before program exit; then shutdown the logger before program exit.
    LogManager.Flush(TimeSpan.FromSeconds(15));
    LogManager.Shutdown();
}