using System.Threading;
using System.Threading.Tasks;
using Evently.Commons.Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Evently.Commons.Infrastructure.Abstractions;

public abstract class DatabaseContextUnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
{
    private readonly TDbContext _dbContext;

    public DatabaseContextUnitOfWork(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellation)
    {
        return _dbContext.SaveChangesAsync(cancellation);
    }
}

