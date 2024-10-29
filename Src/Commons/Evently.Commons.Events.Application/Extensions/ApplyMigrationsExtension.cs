using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Evently.Commons.Application.Extensions;

public static class ApplyMigrationsExtension
{
    public static void ApplyMigrations<TDbContext>(this IApplicationBuilder app)
        where TDbContext : DbContext
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        TDbContext? dbContext = scope.ServiceProvider.GetService<TDbContext>();

        if (dbContext != null)
        {
            dbContext.Database.Migrate();
        }
    }
}
