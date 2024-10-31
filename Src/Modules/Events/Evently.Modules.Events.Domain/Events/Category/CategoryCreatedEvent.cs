using System;
using Evently.Commons.Domain.Abstractions.Entity;

namespace Evently.Modules.Events.Domain.Events.Category;

public sealed class CategoryCreatedEvent : DomainEvent
{
    public CategoryCreatedEvent(Guid categoryId)
    {
        CategoryId = categoryId;
    }

    public Guid CategoryId { get; private set; }
}
