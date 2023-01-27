using MediatR;
using SharedFramework.Abstract.Command;
using SharedFramework.Dtos.Response.CommandResponse;

namespace Application.Features.Commands.Cars
{
    public class CreateCarCommandRequest : ICommand, IRequest<CommandResponse>
    {
        public string BrandId { get; set; }
        public string BodyTypeId { get; set; }
        public string TransmissionId { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public int SeatCount { get; set; }
        public int HorsePower { get; set; }
        public string Color { get; set; }
    }
}
