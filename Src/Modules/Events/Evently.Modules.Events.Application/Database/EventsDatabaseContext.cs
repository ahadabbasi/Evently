using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Application.Database;
public sealed class EventsDatabaseContext : DbContext
{
    public EventsDatabaseContext(DbContextOptions<EventsDatabaseContext> options) : base(options)
    { }

    internal DbSet<Events.Entities.Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Event);
    }
}
