using Application.Features.Cars.Dtos;
using MediatR;
using SharedFramework.Dtos.Dynamic;
using SharedFramework.Dtos.Request;

namespace Application.Features.Cars.Queries.GetCarsListByDynamic
{
    public class GetCarsByDynamicQueryRequest : IRequest<ICollection<CarDetailDto>>
    {
        public PaginationRequest PaginationRequest { get; set; }
        public Dynamic Dynamic { get; set; }
    }
}
