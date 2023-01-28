using Domain.Entites.Base;

namespace Domain.Entities;

public partial class Payment : BaseEntity
{

    public int RentalId { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public float Amount { get; set; }
    public virtual Rental? Rental { get; set; } = null!;
}
