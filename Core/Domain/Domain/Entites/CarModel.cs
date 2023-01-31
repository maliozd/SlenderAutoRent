using Domain.Entites.Base;
using Domain.Entities;

namespace Domain.Entites
{
    public class CarModel : BaseEntity
    {
        public CarModel()
        {
            Cars = new HashSet<Car>();
        }
        public int BrandId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual Brand Brand { get; set; } = null!;
    }
}
