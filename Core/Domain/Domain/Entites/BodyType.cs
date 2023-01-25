using Domain.Entites.Base;

namespace Domain.Entities;

public class BodyType : BaseEntity
{

    public string Name { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; } = new List<Car>();
}

