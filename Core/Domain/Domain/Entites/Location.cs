using Domain.Entites.Base;

namespace Domain.Entities;

public partial class Location : BaseEntity
{
    public string City { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<CarInventory> CarInventories { get; } = new List<CarInventory>();
}
