using NLog.Config;
using NLog.Extensions.Logging;
using NLog.Targets;
using NLog.AWS.Logger;
using NLog;


var builder = WebApplication.CreateBuilder(args);

var config = new LoggingConfiguration();
config.AddRule(NLog.LogLevel.Trace, NLog.LogLevel.Fatal, new ConsoleTarget());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureLogging(builder.Logging);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureLogging(ILoggingBuilder loggingBuilder)
{
    loggingBuilder.ClearProviders();
    loggingBuilder.AddNLog();
}
