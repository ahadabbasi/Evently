using System;
using Evently.Commons.Domain.Contracts;

namespace Evently.Commons.Domain.Abstractions.Entity;

public abstract class DomainEvent : Contracts.IDomainEvent<Guid>
{
    protected DomainEvent() : this(Guid.NewGuid())
    {

    }

    protected DomainEvent(Guid id) : this(id, DateTime.UtcNow)
    {

    }

    protected DomainEvent(Guid id, DateTime occurredOnUtc)
    {
        Id = id;
        OccurredOnUtc = occurredOnUtc;
    }

    public DateTime OccurredOnUtc { get; protected init; }

    public Guid Id { get; protected init; }
}
