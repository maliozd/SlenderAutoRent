using Domain.Entites.Base;

namespace Domain.Entities;

public partial class Transmission : BaseEntity
{
    public Transmission()
    {
        Cars = new HashSet<Car>();
    }
    public string Type { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; }
}
