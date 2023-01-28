using Application.Features.Cars.Dtos;
using Application.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedFramework.Dtos.Response.QueryResponse;
using SharedFramework.Utilities;

namespace Application.Features.Cars.Queries.GetPagedList
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
            var query = _repository.GetAll().
                Include(c => c.Transmission).
                Include(c => c.BodyType).
                Include(c => c.Brand);
            var total = query.Count();
            var pagedEntityist = query.ToPagedList(request);
            var pagedDtoList = _mapper.Map<List<CarDetailDto>>(pagedEntityist);
            return new(pagedDtoList, total, request);
        }
    }
}
