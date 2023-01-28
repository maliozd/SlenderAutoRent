using Application.Features.Cars.Dtos;
using MediatR;
using SharedFramework.Dtos.Request;
using SharedFramework.Dtos.Response.QueryResponse;

namespace Application.Features.Cars.Queries.GetCarsPaged
{
    public class GetCarsPagedQueryRequest : PaginationRequest, IRequest<PaginationQueryResponse<ICollection<CarDetailDto>>>
    {

    }
}
