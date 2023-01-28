using Application.Features.Cars.Dtos;
using Application.Repositories;
using AutoMapper;
using MediatR;
using SharedFramework.Dtos.Response.QueryResponse;

namespace Application.Features.Cars.Queries.GetCarsPaged
{
    public class GetCarsPagedQueryHandler : IRequestHandler<GetCarsPagedQueryRequest, PaginationQueryResponse<ICollection<CarDetailDto>>>
    {
        readonly ICarRepository _repository;
        readonly IMapper _mapper;

        public GetCarsPagedQueryHandler(ICarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        async Task<PaginationQueryResponse<ICollection<CarDetailDto>>> IRequestHandler<GetCarsPagedQueryRequest, PaginationQueryResponse<ICollection<CarDetailDto>>>.Handle(GetCarsPagedQueryRequest request, CancellationToken cancellationToken)
        {
            var repoResponse = _repository.GetPaged(request);
            var pagedDtoList = _mapper.Map<List<CarDetailDto>>(repoResponse.Data);
            return new(pagedDtoList, repoResponse.Meta.Total, request);
        }
    }
}
