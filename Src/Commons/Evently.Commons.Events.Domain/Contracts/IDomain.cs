namespace Evently.Commons.Domain.Contracts;

public interface IDomain<TKey>
{
    TKey Id { get; }
}

