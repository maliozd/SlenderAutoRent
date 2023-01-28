using Application.Features.Cars.Dtos;
using MediatR;

namespace Application.Features.Cars.Queries.GetAllCars
{
    public class GetAllCarsQueryRequest : IRequest<ICollection<CarDetailDto>>
    {
    }
}
