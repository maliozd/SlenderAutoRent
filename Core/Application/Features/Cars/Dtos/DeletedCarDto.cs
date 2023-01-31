namespace Application.Features.Cars.Dtos
{
    public class DeletedCarDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string CarModel { get; set; }

        public string Mileage { get; set; }
        public string Year { get; set; }
    }
}
