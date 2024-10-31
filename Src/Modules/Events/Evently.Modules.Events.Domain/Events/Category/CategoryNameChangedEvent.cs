using System;
using Evently.Commons.Domain.Abstractions.Entity;

namespace Evently.Modules.Events.Domain.Events.Category;

public sealed class CategoryNameChangedEvent : DomainEvent
{
    public CategoryNameChangedEvent(Guid categoryId, string name)
    {
        CategoryId = categoryId;

        Name = name;
    }

    public Guid CategoryId { get; private set; } 

    public string Name { get; private set; } 
}
