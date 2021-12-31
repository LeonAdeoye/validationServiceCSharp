using System.Runtime.Loader;
using Autofac;
using validation_service.Services;
using validation_service.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services via dependency injection.
builder.Services.AddSingleton<IValidationService, ValidationService>();
builder.Services.AddSingleton<IValidatorFactory, ValidatorFactory>();
builder.Services.AddSingleton<EmptyValidator>();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Added all services via dependency injection.");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
