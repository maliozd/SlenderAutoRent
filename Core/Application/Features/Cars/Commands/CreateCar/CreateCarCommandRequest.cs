using Application.Features.Cars.Dtos;
using MediatR;
using SharedFramework.Dtos.Response.Command;

namespace Application.Features.Commands.Cars.Create
{
    public class CreateCarCommandRequest : IRequest<CommandResponse<CarDetailDto>>
    {
        public int BrandId { get; set; }
        public int BodyTypeId { get; set; }
        public int TransmissionId { get; set; }
        public int ColorId { get; set; }
        public int CarModelId { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public int SeatCount { get; set; }
        public int HorsePower { get; set; }
        public string Color { get; set; }
    }
}
