using Application.Features.Auth.Commands.Login;
using FluentValidation;

namespace Application.Features.Auth.Validators
{
    public class LoginValidator : AbstractValidator<LoginCommandRequest>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UsernameOrEmail).NotEmpty().
                NotNull().
                WithMessage("Username or e-mail can't be empty");
            RuleFor(x => x.Password).NotEmpty().
                NotNull().
                WithMessage("Password or e-mail can't be empty");
        }
    }
}
