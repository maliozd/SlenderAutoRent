using Application.Features.Commands.Cars.Create;
using FluentValidation;

namespace Application.Features.Cars.Validators
{
    public class CreateCarValidator : AbstractValidator<CreateCarCommandRequest>
    {
        public CreateCarValidator()
        {
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

            RuleFor(c => c.Color).NotEmpty().
                NotNull().WithMessage("Color can't be empty");
        }
    }
}
