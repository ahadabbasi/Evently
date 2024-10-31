using System.Collections.Generic;
using System.Linq;
using Evently.Commons.Domain.Contracts;

namespace Evently.Commons.Domain.Abstractions;

public abstract class Domain<TKey> : IDomain<TKey>
{
    public TKey Id { get; protected set; }

    private readonly IList<Contracts.DomainEvent<TKey>> _events = new List<Contracts.DomainEvent<TKey>>();

    protected Domain()
    {

    }

    public IReadOnlyCollection<Contracts.DomainEvent<TKey>> Events => _events.ToList();

    public void ClearDomainEvents()
    {
        _events.Clear();
    }

    protected void Raise(Contracts.DomainEvent<TKey> entry)
    {
        _events.Add(entry);
    }
}
