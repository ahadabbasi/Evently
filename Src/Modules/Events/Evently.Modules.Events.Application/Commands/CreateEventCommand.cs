using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evently.Modules.Events.Application.Models;
using MediatR;

namespace Evently.Modules.Events.Application.Commands;

public sealed record CreateEventCommand(
    string Title,
    string Description,
    string Location,
    DateTime StartAtUtc,
    DateTime EndsAtUtc
) : EventRecord(Title, Description, Location, StartAtUtc, EndsAtUtc), 
    IRequest<Guid>;
