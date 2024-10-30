using System;
using Evently.Commons.Application.Contracts;

namespace Evently.Modules.Events.Application.Contracts;

public interface IEventRepository : IRepository<Events.Domain.Entities.Event, Guid>
{
}
