using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddJsonOptions(opts =>
    {
        // делать названия свойств нечувствительными к регистру
        opts.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        // конвертировать enum по строковым именам (тоже case‑insensitive)
        opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Infrastructure & DI
builder.Services.AddSingleton<IAnimalRepository, InMemoryAnimalRepository>();
builder.Services.AddSingleton<IEnclosureRepository, InMemoryEnclosureRepository>();
builder.Services.AddSingleton<IFeedingScheduleRepository, InMemoryFeedingScheduleRepository>();
builder.Services.AddSingleton<IInventoryRepository, InMemoryItemRepository>();
builder.Services.AddSingleton<IEventDispatcher, InMemoryEventDispatcher>();

// Application services
builder.Services.AddScoped<AnimalTransferService>();
builder.Services.AddScoped<FeedingOrganizationService>();
builder.Services.AddScoped<InventoryService>();
builder.Services.AddScoped<VeterinaryClinicService>();
builder.Services.AddScoped<ZooStatisticsService>();
builder.Services.AddScoped<IStatisticsService, ZooStatisticsService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IVeterinaryClinicService, VeterinaryClinicService>();

// MVC + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Zoo API", Version = "v1" });
});



var app = builder.Build();

// Developer exceptions
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Обязательно до endpoint-ов
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Zoo API V1");
    c.RoutePrefix = "swagger"; // UI будет доступен по /swagger
});

// Редирект корня на Swagger UI
app.MapGet("/", () => Results.Redirect("/swagger"));

// API-контроллеры
app.MapControllers();


app.Run();