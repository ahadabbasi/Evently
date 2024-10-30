namespace Evently.Commons.Domain.Contracts;

public interface IEntity<TKey>
{
    TKey Id { get; set; }
}

