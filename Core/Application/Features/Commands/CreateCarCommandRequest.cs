using MediatR;

namespace Application.Features.Commands
{
    public class CreateCarCommandRequest : IRequest
    {
        public string BrandId { get; set; }
        public string BodyTypeId { get; set; }
        public string TransmissionId { get; set; }
        public DateTime Year { get; set; }
        public int Mileage { get; set; }
        public int SeatCount { get; set; }
        public int HorsePower { get; set; }
        public string Color { get; set; }
    }
}
