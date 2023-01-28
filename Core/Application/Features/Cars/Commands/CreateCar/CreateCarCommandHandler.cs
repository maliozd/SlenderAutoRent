using Application.Features.Cars.Dtos;
using Application.Features.Commands.Cars.Create;
using Application.Repositories;
using AutoMapper;
using MediatR;
using SharedFramework.Dtos.Response.Command;

namespace Application.Features.Commands.Cars
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommandRequest, CommandResponse<CreatedCarDto>>
    {
        readonly ICarRepository _carRepository;
        readonly IMapper _mapper;

        public CreateCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<CreatedCarDto>> Handle(CreateCarCommandRequest request, CancellationToken cancellationToken)
        {
            //Car entity = _mapper.Map<Car>(request);
            //await _carRepository.AddAsync(entity);
            //var affectedRow = await _carRepository.SaveAsync();
            //if (affectedRow > 0)
            //    return new(true, affectedRow,)
            throw new Exception();


        }
    }
}
