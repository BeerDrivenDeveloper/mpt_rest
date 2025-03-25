using FluentValidation;
using mpt_rest.Dtos;

namespace mpt_rest.Validators
{
    public class TicketDtoValidator : AbstractValidator<TicketSaveDto>
    {
        public TicketDtoValidator() 
        {
            RuleFor(ticketDto => ticketDto.Title)
            .NotEmpty().WithMessage("Empty title");

            RuleFor(ticketDto => ticketDto.VisitorsNumber)
              .InclusiveBetween(1, 10).WithMessage("{PropertyName} value {PropertyValue} is not allowed. Value must be in interval [{From}.{To}]");

            RuleFor(ticketDto => ticketDto.VisitDate)
                .GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("Ticket creation in the past is disabled");
        }
    }
}
