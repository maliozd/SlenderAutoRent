using Domain.Entites.Base;

namespace Domain.Entities;

public partial class Transmission : BaseEntity
{

    public string Type { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; } = new List<Car>();
}
