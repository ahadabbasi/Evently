using System.Collections.Generic;
using System.Linq;
using Evently.Commons.Domain.Contracts;

namespace Evently.Commons.Domain.Abstractions.Entity;

public abstract class Domain<TKey> : IDomain<TKey>
{
    public TKey Id { get; protected set; }

    private readonly IList<Contracts.IDomainEvent<TKey>> _events = new List<Contracts.IDomainEvent<TKey>>();

    protected Domain()
    {

    }

    public IReadOnlyCollection<Contracts.IDomainEvent<TKey>> Events => _events.ToList();

    public void ClearDomainEvents()
    {
        _events.Clear();
    }

    protected void Raise(Contracts.IDomainEvent<TKey> entry)
    {
        _events.Add(entry);
    }
}
