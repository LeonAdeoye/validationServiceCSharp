using System.Runtime.Loader;
using Autofac;
using validation_service.Services;
using validation_service.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IValidationService, ValidationService>();
builder.Services.AddSingleton<IValidatorFactory, ValidatorFactory>();
builder.Services.AddSingleton<EmptyValidator>();

var app = builder.Build();

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
