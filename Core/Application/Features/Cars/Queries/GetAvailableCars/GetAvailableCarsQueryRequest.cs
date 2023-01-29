using Application.Features.Cars.Dtos;
using MediatR;

namespace Application.Features.Cars.Queries.GetAvailableCars
{
    public class GetAvailableCarsQueryRequest : IRequest<ICollection<CarDetailDto>>
    {
    }
}
