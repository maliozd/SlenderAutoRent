using Application.Features.Cars.Dtos;
using MediatR;
using SharedFramework.Dtos.Response.Command;

namespace Application.Features.Commands.Cars.Create
{
    public class CreateCarCommandRequest : IRequest<CommandResponse<CreatedCarDto>>
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
