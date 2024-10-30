using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Infrastructure.Database.Contexts;

public sealed class EventsDatabaseContext : DbContext
{
    public EventsDatabaseContext(DbContextOptions<EventsDatabaseContext> options) : base(options)
    { }

    internal DbSet<Domain.Entities.Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Event);
    }
}
