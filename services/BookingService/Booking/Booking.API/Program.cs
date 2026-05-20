using Asp.Versioning;
using BookingSystem.API.Middlewares;
using BookingSystem.Application.DependencyInjection;
using BookingSystem.Application.Features.Services.Command.CreateService;
using BookingSystem.Infrastructure.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using System.Reflection;


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .MinimumLevel.Override("System", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.Seq("http://localhost:5342")
    .CreateLogger();


var builder = WebApplication.CreateBuilder(args);

//Serilog configuration
builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

// API Versioning
builder.Services.AddApiVersioning(options =>
{
    // default version
    options.DefaultApiVersion = new ApiVersion(1, 0);

    // nếu client không truyền version -> dùng default
    options.AssumeDefaultVersionWhenUnspecified = true;

    // response header:
    // api-supported-versions
    // api-deprecated-versions
    options.ReportApiVersions = true;
})
.AddApiExplorer(options =>
{
    // format version
    options.GroupNameFormat = "'v'VVV";

    // replace version trong route
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Booking API V1",
        Version = "v1"
    });

    options.SwaggerDoc("v2", new OpenApiInfo
    {
        Title = "Booking API V2",
        Version = "v2"
    });

    // XML Comment
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();


//app.UseSerilogRequestLogging(); // auto request log

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");

    options.SwaggerEndpoint("/swagger/v2/swagger.json", "API V2");
});
//app.UseExceptionHandler("/error");
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<RequestTimingMiddleware>();
app.MapControllers();

app.Run();
