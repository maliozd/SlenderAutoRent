using Application.Features.Cars.Dtos;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Cars.Queries.GetAllCars
{
    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQueryRequest, ICollection<CarDetailDto>>
    {
        readonly ICarRepository _carRepository;
        readonly IMapper _mapper;

        public GetAllCarsQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<CarDetailDto>> Handle(GetAllCarsQueryRequest request, CancellationToken cancellationToken)
        {
            var repositoryData = await _carRepository.GetAllWithSpecsIncludedAsync();
            var responseData = _mapper.Map<List<CarDetailDto>>(repositoryData);
            return responseData;
        }
    }
}
