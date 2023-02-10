using Application.Features.Cars.Dtos;
using Application.Repositories;
using AutoMapper;
using MediatR;
using SharedFramework.Dtos.Response.QueryResponse;

namespace Application.Features.Cars.Queries.GetCarsByBrand
{
    public class GetCarsPagedByBrandQueryHandler : IRequestHandler<GetCarsPagedByBrandQueryRequest, PaginationQueryResponse<ICollection<CarDetailDto>>>
    {
        readonly ICarRepository _carRepository;
        readonly IMapper _mapper;

        public GetCarsPagedByBrandQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<PaginationQueryResponse<ICollection<CarDetailDto>>> Handle(GetCarsPagedByBrandQueryRequest request, CancellationToken cancellationToken)
        {
            SharedFramework.Dtos.Request.PaginationRequest paginatonRequest = new(request.Pagination.Page, request.Pagination.PerPage);
            var data = _carRepository.GetCarsPagedByBrand(request.BrandId, paginatonRequest);
            var carDetailDto = _mapper.Map<List<CarDetailDto>>(data.Data);
            return new(carDetailDto, data.Meta.Total, request.Pagination);
        }
    }
}
