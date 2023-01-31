using Domain.Entites.Base;

namespace Domain.Entities;

public partial class Location : BaseEntity
{
    public Location()
    {
        CarInventories = new HashSet<CarInventory>();
    }
    public string City { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<CarInventory> CarInventories { get; }
}
