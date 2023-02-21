using Application.Features.Auth.Dtos;
using Domain.Entites.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
    {
        readonly UserManager<AppUser> _userManager;

        public RegisterCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegisterCommandResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser user = new()
            {
                Name = request.Name,
                Surname = request.Surname,
                UserName = request.Username,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                Email = request.Email,
                RegistrationDate = DateTime.UtcNow
            };
            IdentityResult result = await _userManager.CreateAsync(user, request.Password);
            return new() { Success = result.Succeeded == true ? true : false };

        }
    }
}
