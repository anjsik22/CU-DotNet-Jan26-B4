using FluentValidation;
using TicketBookingSystem.TripService.DTOs;

namespace TicketBookingSystem.TripService.Validators
{
    public class CreateTripValidator:AbstractValidator<CreateTripDto>
    {
        public CreateTripValidator()
        {
            RuleFor(x => x.Heading)
                .NotEmpty().WithMessage("Heading is required");

            RuleFor(x => x.ShipName)
                .NotEmpty().WithMessage("Ship name is required");

            RuleFor(x => x.Nights)
                .GreaterThan(0).WithMessage("Nights must be greater than 0");

            RuleFor(x => x.Price)
                .GreaterThan(40000).WithMessage("Price must be greater than 40000");

            RuleFor(x => x.StartDate)
                .LessThan(x => x.EndDate)
                .WithMessage("StartDate must be before EndDate");

            RuleFor(x => x.Ports)
                .NotEmpty().WithMessage("At least one port is required");
        }
    }
}
