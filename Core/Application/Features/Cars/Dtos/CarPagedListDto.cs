using SharedFramework.Dtos.Request;
using SharedFramework.Dtos.Response.QueryResponse;

namespace Application.Features.Cars.Dtos
{
    public class CarPagedListDto : PaginationQueryResponse<CarDetailDto>
    {
        public CarPagedListDto(CarDetailDto data, int total, PaginationRequest request) : base(data, total, request)
        {
        }
    }
}
