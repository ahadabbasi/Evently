using System;
using Evently.Commons.Domain.Contracts;

namespace Evently.Modules.Events.Domain.Entities;

public sealed class Event : IEntity<Guid>
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Location { get; set; }

    public DateTime StartAtUtc { get; set; }

    public DateTime EndsAtUtc { get; set; }

    public EventStatus Status { get; set; }
}
