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
            var car = _mapper.Map<Car>(request);
            _carRepository.Update(car);
            var affectedRow = await _carRepository.SaveAsync();
            if (affectedRow > 0)
            {
                var affectedData = _mapper.Map<UpdatedCarDto>(car);
                return new(true, affectedRow, UpdateCommandMesageConstants.Success, affectedData);
            }

            return new()



        }
    }
}
