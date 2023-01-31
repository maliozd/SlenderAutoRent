using Application.Features.Cars.Dtos;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using SharedFramework.Constants;
using SharedFramework.Dtos.Response.Command;

namespace Application.Features.Cars.Commands.UpdateCar
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommandRequest, CommandResponse<UpdatedCarDto>>
    {
        readonly ICarRepository _carRepository;
        readonly IMapper _mapper;

        public UpdateCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<UpdatedCarDto>> Handle(UpdateCarCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _carRepository.Update(_mapper.Map<Car>(request));
                var affectedRow = await _carRepository.SaveAsync();
                if (affectedRow > 0)
                {
                    var updatedCar = await _carRepository.GetByIdWithNavigationsAsync(request.Id);
                    var affectedData = _mapper.Map<UpdatedCarDto>(updatedCar);
                    return new(true, affectedRow, UpdateCommandMesageConstants.Success, affectedData);
                }
                return new(false, UpdateCommandMesageConstants.Error);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
