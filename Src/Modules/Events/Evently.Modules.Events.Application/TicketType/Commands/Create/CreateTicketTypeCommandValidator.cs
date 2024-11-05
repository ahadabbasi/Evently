using FluentValidation;

namespace Evently.Modules.Events.Application.TicketType.Commands.Create;

internal class CreateTicketTypeCommandValidator : AbstractValidator<CreateTicketTypeCommand>
{
    public CreateTicketTypeCommandValidator()
    {
        RuleFor(c => c.EventId).NotEmpty().NotEqual(System.Guid.Empty);
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Price).GreaterThan(decimal.Zero);
        RuleFor(c => c.Currency).NotEmpty();
        RuleFor(c => c.Quantity).GreaterThan(decimal.Zero);
    }
}
