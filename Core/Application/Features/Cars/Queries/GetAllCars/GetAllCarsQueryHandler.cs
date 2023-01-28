using Application.Features.Cars.Dtos;
using Application.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            var query = _carRepository.GetAll().Include(c => c.BodyType).Include(c => c.Transmission).Include(c => c.Brand);
            var responseData = _mapper.Map<List<CarDetailDto>>(await query.ToListAsync());
            return responseData;
        }
    }
}
