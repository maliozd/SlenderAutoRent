using Domain.Entites.Base;

namespace Domain.Entities;

public partial class CarInventory : BaseEntity
{

    public CarInventory()
    {
        Cars = new HashSet<Car>();
    }
    public int LocationId { get; set; }

    public virtual ICollection<Car> Cars { get; }

    public virtual Location Location { get; set; } = null!;
}
