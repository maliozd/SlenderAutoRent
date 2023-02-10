using Application.Features.Cars.Dtos;
using Application.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Queries.GetCarsListByDynamic
{
    public class GetCarsByDynamicQueryHandler : IRequestHandler<GetCarsByDynamicQueryRequest, ICollection<CarDetailDto>>
    {
        readonly ICarRepository _carRepository;
        readonly IMapper _mapper;
        public GetCarsByDynamicQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<CarDetailDto>> Handle(GetCarsByDynamicQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _carRepository.GetListByDynamicAsync(request.Dynamic,
                c => c.Include(c => c.CarModel).
                       Include(c => c.Brand).
                       Include(c => c.Transmission).
                       Include(c => c.Color));
            List<CarDetailDto> result = _mapper.Map<List<CarDetailDto>>(data);
            return result;
        }
    }
}
