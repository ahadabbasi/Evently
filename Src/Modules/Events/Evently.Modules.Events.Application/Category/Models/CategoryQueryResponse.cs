using System;

namespace Evently.Modules.Events.Application.Category.Models;

public sealed record CategoryQueryResponse(
    Guid Id, 
    string Name, 
    bool IsArchived
) : CategoryRecord(Name, IsArchived);
