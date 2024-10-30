using System.Threading;
using System.Threading.Tasks;

namespace Evently.Commons.Application.Contracts;

public interface IUnitOfWork
{

    Task<int> SaveChangesAsync(CancellationToken cancellation);
}
