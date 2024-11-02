using Evently.Commons.Application.Extensions;
using Evently.Modules.Events.Application.Contracts;
using Evently.Modules.Events.Application.Contracts.Repositories;
using Evently.Modules.Events.Infrastructure.Implementations;
using Evently.Modules.Events.Infrastructure.Implementations.Repositories;
using Evently.Modules.Events.Presentation;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evently.Modules.Events.Infrastructure;

public static class EventsModuleStartup
{
    public static IServiceCollection AddEventModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(serviceConfiguration => {
            serviceConfiguration.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly);
        });

        services.AddValidatorsFromAssembly(Application.AssemblyReference.Assembly, includeInternalTypes: true);

        services.AddEventInfrastructure(configuration);

        return services;
    }

    private static void AddEventInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string databaseConnectionString = configuration.GetConnectionString("SqliteDefault")!;

        services.AddDbContext<Database.Contexts.EventsDatabaseContext>(options =>
            options.UseSqlite(
                databaseConnectionString,
                sqliteOptions => sqliteOptions
                    .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Database.Schemas.Event)
            )
            .UseSnakeCaseNamingConvention()
        );

        services.AddScoped<IEventRepository, EventRepository>();

        services.AddScoped<IEventUnitOfWork, EventUnitOfWork>();

        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
    }

    public static void MapEventEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapEndpoints();
    }

    public static void ApplyEventMigration(this IApplicationBuilder app)
    {
        app.ApplyMigrations<Database.Contexts.EventsDatabaseContext>();
    }
}
