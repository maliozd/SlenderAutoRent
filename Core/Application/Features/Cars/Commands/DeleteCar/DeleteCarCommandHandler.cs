using Application.Features.Cars.Dtos;
using Application.Repositories;
using AutoMapper;
using MediatR;
using SharedFramework.Constants;
using SharedFramework.Dtos.Response.Command;

namespace Application.Features.Cars.Commands.DeleteCar
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommandRequest, CommandResponse<DeletedCarDto>>
    {
        readonly ICarRepository _carRepository;
        readonly IMapper _mapper;

        public DeleteCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<DeletedCarDto>> Handle(DeleteCarCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedCar = _mapper.Map<DeletedCarDto>(await _carRepository.GetByIdAsync(request.Id));
            await _carRepository.DeleteByIdAsync(request.Id);
            var affectedRow = await _carRepository.SaveAsync();
            if (affectedRow > 0)
                return new(true, affectedRow, DeleteCommandMessageConstants.Success, deletedCar);
            return new(false, DeleteCommandMessageConstants.Error);
        }
    }
}
