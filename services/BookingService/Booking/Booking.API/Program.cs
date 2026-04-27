using BookingSystem.API.Middlewares;
using BookingSystem.Application.DependencyInjection;
using BookingSystem.Application.Features.Services.Command.CreateService;
using BookingSystem.Infrastructure.DependencyInjection;
using Serilog;
using Serilog.Events;


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
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);


builder.Services.AddApplication();

var app = builder.Build();


//app.UseSerilogRequestLogging(); // auto request log

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
//app.UseExceptionHandler("/error");
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<RequestTimingMiddleware>();
app.MapControllers();

app.Run();
