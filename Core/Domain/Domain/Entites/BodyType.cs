using Domain.Entites.Base;

namespace Domain.Entities;

public class BodyType : BaseEntity
{
    public BodyType()
    {
        Cars = new HashSet<Car>();
    }
    public string Name { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; }
}

