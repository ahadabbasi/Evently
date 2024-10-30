using Evently.Commons.Application.Extensions;
using Evently.Modules.Events.Application.Events.Endpoints.Create;
using Evently.Modules.Events.Application.Events.Endpoints.Get;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evently.Modules.Events.Application;

public static class EventsModule
{
    public static IServiceCollection AddEventModule(this IServiceCollection services, IConfiguration configuration)
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

        return services;
    }

    public static void MapEventEndpoints(this IEndpointRouteBuilder app)
    {
        CreateEvent.MapEndpoint(app);
        GetEvent.MapEndpoint(app);
    }

    public static void ApplyEventMigration(this IApplicationBuilder app)
    {
        app.ApplyMigrations<Database.Contexts.EventsDatabaseContext>();
    }
}
