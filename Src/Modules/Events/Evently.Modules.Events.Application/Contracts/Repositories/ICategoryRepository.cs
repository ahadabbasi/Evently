using System;
using Evently.Commons.Application.Contracts;
using Evently.Modules.Events.Domain.Entities;

namespace Evently.Modules.Events.Application.Contracts.Repositories;
public interface ICategoryRepository : IRepository<Domain.Entities.Category, Guid>
{
}
