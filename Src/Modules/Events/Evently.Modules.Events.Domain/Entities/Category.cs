using System;
using Evently.Commons.Domain.Abstractions.Entity;
using Evently.Modules.Events.Domain.Events.Category;

namespace Evently.Modules.Events.Domain.Entities;

public sealed class Category : Domain<Guid>
{
    public string Name { get; private set; }

    public bool IsArchived { get; private set; }

    public static Category Create(string name)
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = name,
            IsArchived = false
        };

        category.Raise(new CategoryCreatedEvent(category.Id));

        return category;
    }

    public void Archive()
    {
        IsArchived = true;

        Raise(new CategoryArchivedEvent(Id));
    }

    public void ChangeName(string name)
    {
        if (Name.ToUpper().Equals(name.ToUpper()))
        {
            return;
        }

        Name = name;

        Raise(new CategoryNameChangedEvent(Id, Name));
    }
}
