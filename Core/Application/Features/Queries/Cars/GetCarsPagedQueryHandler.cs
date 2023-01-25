using Application.Repositories;
using Domain.Entities;
using MediatR;
using SharedFramework.Dtos.Response.QueryResponse;
using SharedFramework.Utilities;

namespace Application.Features.Queries.Cars
{
    public class GetCarsPagedQueryHandler : IRequestHandler<GetCarsPagedQueryRequest, PaginationQueryResponse<ICollection<Car>>>
    {
        readonly ICarRepository _repository;

        public GetCarsPagedQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        async Task<PaginationQueryResponse<ICollection<Car>>> IRequestHandler<GetCarsPagedQueryRequest, PaginationQueryResponse<ICollection<Car>>>.Handle(GetCarsPagedQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAll();
            var total = query.Count();
            var pagedList = query.ToPagedList(request);
            return new(pagedList, total, request);
        }
    }
}
