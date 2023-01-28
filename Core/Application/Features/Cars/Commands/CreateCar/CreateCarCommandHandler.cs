using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Features.Commands.Cars.Create;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using SharedFramework.Constants;
using SharedFramework.Dtos.Response.Command;

namespace Application.Features.Commands.Cars
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommandRequest, CommandResponse<CarDetailDto>>
    {
        readonly ICarRepository _carRepository;
        readonly IMapper _mapper;
        readonly CarBusinessRules _carBusinessRules;
        public CreateCarCommandHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules carBusinessRules)
        {
            _carRepository = carRepository;
            _mapper = mapper;
            _carBusinessRules = carBusinessRules;
        }
        public async Task<CommandResponse<CarDetailDto>> Handle(CreateCarCommandRequest request, CancellationToken cancellationToken)
        {
            Car entity = _mapper.Map<Car>(request);
            entity = _carBusinessRules.CarStateMustBeAvailableOnCreating(entity);
            await _carRepository.AddAsync(entity);
            var affectedRow = await _carRepository.SaveAsync();

            if (affectedRow > 0)
            {
                var affectedData = _mapper.Map<CarDetailDto>(await _carRepository.GetByIdWithNavigationsAsync(entity.Id));
                return new(true, affectedRow, CreateCommandMessageConstants.Success, affectedData);
            }
            return new(false, CreateCommandMessageConstants.Error);
        }
    }
}
