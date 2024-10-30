using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Evently.Commons.Application.Contracts;
using Evently.Commons.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Evently.Commons.Infrastructure.Abstractions;

public abstract class DatabaseContextRepository<TDbContext, TEntity, TKey> : IRepository<TEntity, TKey> 
    where TEntity : class, IEntity<TKey>
    where TDbContext : DbContext
{
    protected TDbContext Context { get; }

    protected DbSet<TEntity> Set { get; }

    public DatabaseContextRepository(TDbContext context)
    {
        Context = context;

        Set = context.Set<TEntity>();
    }

    public Task<bool> ExistAsync(TKey id, CancellationToken cancellation)
    {
        return ExistAsync(model => model.Id!.Equals(id), cancellation);
    }

    public Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation)
    {
        return Query().AnyAsync(predicate, cancellation);
    }

    public async Task InsertAsync(TEntity entity, CancellationToken cancellation)
    {
        await Set.AddAsync(entity, cancellation);
    }

    public IQueryable<TEntity> Query()
    {
        return Set;
    }
}
