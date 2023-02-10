using Application.Features.Cars.Dtos;
using MediatR;
using SharedFramework.Dtos.Request;
using SharedFramework.Dtos.Response.QueryResponse;

namespace Application.Features.Cars.Queries.GetCarsByBrand
{
    public class GetCarsPagedByBrandQueryRequest : IRequest<PaginationQueryResponse<ICollection<CarDetailDto>>>
    {
        public PaginationRequest Pagination { get; set; }
        public int BrandId { get; set; }
    }
}
