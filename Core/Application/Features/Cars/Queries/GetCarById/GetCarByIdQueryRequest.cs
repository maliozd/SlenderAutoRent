using Application.Features.Cars.Dtos;
using MediatR;

namespace Application.Features.Cars.Queries.GetCarById
{
    public class GetCarByIdQueryRequest : IRequest<CarDetailDto>
    {
        public int Id { get; set; }
    }
}
