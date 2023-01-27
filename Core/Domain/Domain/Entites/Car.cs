using Domain.Entites.Base;

namespace Domain.Entities;

public partial class Car : BaseEntity
{

    public Guid BrandId { get; set; }

    public Guid BodyTypeId { get; set; }

    public Guid TransmissionId { get; set; }

    public Guid? CarInventoryId { get; set; }
    public int Year { get; set; }

    public int Mileage { get; set; }

    public int SeatCount { get; set; }

    public int HorsePower { get; set; }

    public string Color { get; set; } = null!;


    public virtual BodyType BodyType { get; set; } = null!;

    public virtual Brand Brand { get; set; } = null!;

    public virtual CarInventory? CarInventory { get; set; }

    public virtual ICollection<Rental> Rentals { get; } = new List<Rental>();

    public virtual Transmission Transmission { get; set; } = null!;
}
