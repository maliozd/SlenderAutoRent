using Application.Features.Cars.Dtos;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Cars.Queries.GetCarById
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQueryRequest, CarDetailDto>
    {
        readonly ICarRepository _carRepository;
        readonly IMapper _mapper;

        public GetCarByIdQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<CarDetailDto> Handle(GetCarByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetByIdWithNavigationsAsync(request.Id);
            var responseData = _mapper.Map<CarDetailDto>(car);
            return responseData;
        }
    }
}
