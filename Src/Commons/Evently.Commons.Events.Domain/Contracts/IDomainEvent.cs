using System;

namespace Evently.Commons.Domain.Contracts;

public interface DomainEvent<TKey> : IDomain<TKey>
{ 
    DateTime OccurredOnUtc { get; }
}
