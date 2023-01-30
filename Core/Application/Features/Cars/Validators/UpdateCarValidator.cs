using Application.Features.Cars.Commands.UpdateCar;
using FluentValidation;

namespace Application.Features.Cars.Validators
{
    public class UpdateCarValidator : AbstractValidator<UpdateCarCommandRequest>
    {
        public UpdateCarValidator()
        {
            RuleFor(x => x.Id).
                NotEmpty().
                NotNull().
                WithMessage("Id can't be empty");
            RuleFor(c => c.BrandId).NotEmpty().
                NotNull().
                WithMessage("Brand can't be empty");
            RuleFor(c => c.BodyTypeId).NotEmpty().
                NotNull().
                WithMessage("Body type can't be empty.");
            RuleFor(c => c.TransmissionId).NotEmpty().
                NotNull().
                WithMessage("Transmission can't be empty");
            RuleFor(c => c.Year).
                NotEmpty().
                NotNull().
                WithMessage("Year can't be empty").
                LessThan(DateTime.Now.Year).
                WithMessage($"Year can't be higher than ${DateTime.Now.Year}").
                GreaterThanOrEqualTo(2010).
                WithMessage("Year can't be earlier than 2010");
            RuleFor(c => c.Mileage).NotEmpty().
                NotNull().
                WithMessage("Mileage can't be empty");
            RuleFor(c => c.SeatCount).
                NotEmpty().
                NotNull().
                WithMessage("Seat count can't be empty");
            RuleFor(c => c.HorsePower).
                NotEmpty().
                NotNull().
                WithMessage("Horse power can't be empty");
            RuleFor(c => c.State).
                NotNull().NotEmpty().
                WithMessage("State can't be empty").
                Must(x => (x > 0) && (x < 4)).
                WithMessage("Enter a valid state number. Between 1-4");
        }
    }
}
