using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Evently.Commons.Domain.Contracts;

namespace Evently.Commons.Application.Contracts;

public interface IRepository<TEntity, TKey> where TEntity : class, IDomain<TKey>
{
    IQueryable<TEntity> Query();

    Task InsertAsync(TEntity entity, CancellationToken cancellation);

    Task<bool> ExistAsync(TKey id, CancellationToken cancellation);

    Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation);
}
