using Application.Repositories;
using AutoMapper;
using Domain.Entites.Identity;
using MediatR;
using SharedFramework.Services;

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, RegisteredCommandResponse>
    {
        readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
        }

        public async Task<RegisteredCommandResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            byte[] passwordHash, passwordSalt;
            HashHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
            User user = new()
            {
                Name = request.Name,
                Surname = request.Surname,
                Username = request.Username,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                RegistrationDate = DateTime.UtcNow
            };
            await _userRepository.AddAsync(user);
            var affectedRows = await _userRepository.SaveAsync();
            if (affectedRows > 0)
            {
                return new() { Success = true };
            }
            return new() { Success = false };
        }
    }
}
