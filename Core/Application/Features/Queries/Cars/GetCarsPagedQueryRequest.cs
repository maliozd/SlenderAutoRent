using Application.Features.Queries.Cars.Dtos;
using MediatR;
using SharedFramework.Dtos.Request;
using SharedFramework.Dtos.Response.QueryResponse;

namespace Application.Features.Queries.Car
{
    public class GetCarsPagedQueryRequest : PaginationRequest, IRequest<PaginationQueryResponse<ICollection<CarDto>>>
    {

    }
}
