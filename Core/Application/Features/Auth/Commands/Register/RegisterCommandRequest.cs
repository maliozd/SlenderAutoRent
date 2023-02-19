using MediatR;

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterCommandRequest : IRequest<RegisteredCommandResponse>
    {
        public string Username { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
