using Application.Features.Cars.Dtos;
using MediatR;
using SharedFramework.Dtos.Response.Command;

namespace Application.Features.Cars.Commands.DeleteCar
{
    public class DeleteCarCommandRequest : IRequest<CommandResponse<DeletedCarDto>>
    {
        public int Id { get; set; }
    }
}
