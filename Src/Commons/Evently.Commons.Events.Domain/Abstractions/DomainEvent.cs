using System;
using Evently.Commons.Domain.Contracts;

namespace Evently.Commons.Domain.Abstractions;

public abstract class DomainEvent<TKey> : Contracts.DomainEvent<TKey>
{
    protected DomainEvent() : this(default)
    {

    }

    protected DomainEvent(TKey? id) : this(id, DateTime.UtcNow)
    {

    }

    protected DomainEvent(TKey? id, DateTime occurredOnUtc)
    {
        Id = id ?? throw new Exception();
        OccurredOnUtc = occurredOnUtc;
    }

    public DateTime OccurredOnUtc { get; init; }

    public TKey Id { get; init; }
}
