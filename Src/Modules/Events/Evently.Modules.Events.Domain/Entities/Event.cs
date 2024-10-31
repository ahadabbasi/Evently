using System;
using Evently.Commons.Domain.Abstractions;
using Evently.Commons.Domain.Contracts;
using Evently.Modules.Events.Domain.Events;

namespace Evently.Modules.Events.Domain.Entities;

public sealed class Event : Domain<Guid>
{
    private Event()
    {

    }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public string Location { get; private set; }

    public DateTime StartAtUtc { get; private set; }

    public DateTime? EndsAtUtc { get; private set; }

    public EventStatus Status { get; private set; }

    public static Event Create(
        string title,
        string description,
        string location,
        DateTime startAtUtc,
        DateTime? endsAtUtc
    )
    {
        var result = new Event()
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description,
            Location = location,
            StartAtUtc = startAtUtc,
            EndsAtUtc = endsAtUtc,
            Status = EventStatus.Draft
        };

        result.Raise(new EventCreatedDomainEvent(result.Id));

        return result;
    }
}
