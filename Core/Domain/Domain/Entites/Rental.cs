using Domain.Entites.Base;

namespace Domain.Entities;

public partial class Rental : BaseEntity
{

    public Guid CustomerId { get; set; }

    public Guid CarId { get; set; }

    public DateTime PickUpDate { get; set; }

    public DateTime ReturnDate { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
