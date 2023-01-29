using Application.Features.Cars.Dtos;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Cars.Queries.GetAvailableCars
{
    public class GetAvailableCarsQueryHandler : IRequestHandler<GetAvailableCarsQueryRequest, ICollection<CarDetailDto>>
    {
        readonly ICarRepository _carRepository;
        readonly IMapper _mapper;
        public GetAvailableCarsQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<CarDetailDto>> Handle(GetAvailableCarsQueryRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<CarDetailDto>>(await _carRepository.GetAvailableCarsAsync());
        }
    }
}
