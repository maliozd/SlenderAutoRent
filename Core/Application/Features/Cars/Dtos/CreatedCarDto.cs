using Domain.Enums;

namespace Application.Features.Cars.Dtos
{
    public class CreatedCarDto
    {
        public string BrandId { get; set; }
        public string BodyTypeId { get; set; }
        public CarState CarState { get; set; } = CarState.Available;
        public string TransmissionId { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public int SeatCount { get; set; }
        public int HorsePower { get; set; }
        public string Color { get; set; }
    }
}
