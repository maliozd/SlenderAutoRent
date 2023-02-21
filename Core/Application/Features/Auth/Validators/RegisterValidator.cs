using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Rules;
using FluentValidation;

namespace Application.Features.Auth.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterValidator(AuthBusinessRules authBusinessRules)
        {
            RuleFor(x => x.Username).
                Must(x => authBusinessRules.IsUsernameExist(x) == false).
                WithMessage("This username was taken! Choose another one.").
                NotEmpty().NotNull().
                WithMessage("Username can't be empty!");

            RuleFor(x => x.Name).
                NotEmpty().NotNull().
                WithMessage("Name can't be empty!");

            RuleFor(x => x.Surname).
                NotEmpty().NotNull().
                WithMessage("Surname can't be empty!");

            RuleFor(x => x.Password).
                Must(x => authBusinessRules.PasswordMustContainSpecialCharacters(x) == true).
                WithMessage("Password must contain uppercase character.").
                NotEmpty().NotNull().
                WithMessage("Password can't be empty!");

            RuleFor(x => x.Email).
                Must(x => authBusinessRules.IsEmailExist(x) == false).
                WithMessage("Email already exist.").
                EmailAddress().WithMessage("Please enter a valid email address.").
                NotEmpty().NotNull().
                WithMessage("Email can't be empty!");

            RuleFor(x => x.Address).
                NotEmpty().NotNull().
                WithMessage("Address can't be empty!");

            RuleFor(x => x.PhoneNumber).
                MinimumLength(10).
                WithMessage("Please enter a valid phone number.").
                NotEmpty().NotNull().
                WithMessage("PhoneNumber can't be empty!");


        }

    }
}
