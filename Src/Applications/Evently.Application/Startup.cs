using System;
using System.Linq;
using Evently.Application.Models;
using Evently.Modules.Events.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Evently.Application;

public static class Startup
{
    public static void ConfigurationService(IServiceCollection services, IConfiguration configuration)
    {
        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();

        services.AddEventModule(configuration);
    }

    public static void Configuration(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.ApplyEventMigration();
        }

        app.UseHttpsRedirection();

        app.MapEventEndpoints();

        string[] summaries = new[]
        {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching"
        };

        app.MapGet("/weatherforecast", () =>
        {
            WeatherForecast[] forecast = Enumerable.Range(1, 5).Select(index => {
                return new WeatherForecast
                (
                    DateOnly.FromDateTime(
                        DateTime.Now.AddDays(index)
                    ),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                );
            })
            .ToArray();
            return forecast;
        })
            .WithName("GetWeatherForecast");
    }
}
