using Domain.Entities;
using MediatR;
using SharedFramework.Dtos.Pagination;
using SharedFramework.Dtos.Response.QueryResponse;

namespace Application.Features.Queries.Cars
{
    public class GetCarsPagedQueryRequest : PaginationRequest, IRequest<PaginationQueryResponse<ICollection<Car>>>
    {

    }
}
