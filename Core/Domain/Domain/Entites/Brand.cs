using Domain.Entites;
using Domain.Entites.Base;

namespace Domain.Entities;

public partial class Brand : BaseEntity
{
    public Brand()
    {
        Cars = new HashSet<Car>();
        CarModels = new HashSet<CarModel>();
    }
    public string Name { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; }
    public virtual ICollection<CarModel> CarModels { get; }
}
