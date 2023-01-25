using Domain.Entites.Base;

namespace Domain.Entities;

public partial class CarInventory : BaseEntity
{

    public Guid LocationId { get; set; }

    public virtual ICollection<Car> Cars { get; } = new List<Car>();

    public virtual Location Location { get; set; } = null!;
}
