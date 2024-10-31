using System;

namespace Evently.Commons.Domain.Contracts;

public interface IDomainEvent<TKey> : IDomain<TKey>
{ 
    DateTime OccurredOnUtc { get; }
}
