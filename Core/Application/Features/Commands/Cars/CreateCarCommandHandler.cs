using Application.Services.Abstract;
using MediatR;
using SharedFramework.Dtos.Response.CommandResponse;
namespace Application.Features.Commands.Cars
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommandRequest, CommandResponse>
    {
        readonly ICarService _carService;

        public CreateCarCommandHandler(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<CommandResponse> Handle(CreateCarCommandRequest request, CancellationToken cancellationToken)
        {
            return await _carService.InsertAsync(request);
        }
    }
}
