using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evently.Commons.Application.Contracts.Messaging.Command;

namespace Evently.Modules.Events.Application.TicketType.Commands.UpdatePrice;
public sealed record UpdatePriceTicketTypeCommand(
    Guid Id, 
    decimal Price
) : ICommand;
