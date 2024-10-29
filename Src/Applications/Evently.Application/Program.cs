using System;
using System.Linq;
using Evently.Application.Models;
using Evently.Modules.Events.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Evently.Application;

public static class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddEventModule(builder.Configuration);

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
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

        app.Run();

    }
}

