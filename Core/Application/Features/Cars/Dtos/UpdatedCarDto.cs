namespace Application.Features.Cars.Dtos
{
    public class UpdatedCarDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string BodyType { get; set; }
        public string Transmission { get; set; }
        public string CarModel { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public int SeatCount { get; set; }
        public int HorsePower { get; set; }
        public string Color { get; set; }
        public string State { get; set; }

    }
}