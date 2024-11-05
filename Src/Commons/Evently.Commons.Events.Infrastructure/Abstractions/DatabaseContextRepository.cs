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
    where TEntity : class, IDomain<TKey>
    where TDbContext : DbContext
{
    protected TDbContext Context { get; }

    protected DbSet<TEntity> Set { get; }

    public DatabaseContextRepository(TDbContext context)
    {
        Context = context;

        Set = context.Set<TEntity>();
    }

    public Task<bool> ExistByIdAsync(TKey id, CancellationToken cancellation)
    {
        return ExistAsync(GenerateExpressionBaseOnId(id), cancellation);
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

    public Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellation)
    {
        return Query()
            .FirstOrDefaultAsync(GenerateExpressionBaseOnId(id), cancellation);
    }

    protected Expression<Func<TEntity, bool>> GenerateExpressionBaseOnId(TKey id)
    {
        return model => model.Id != null && model.Id.Equals(id);
    }
}
