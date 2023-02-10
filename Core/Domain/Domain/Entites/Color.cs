using Domain.Entites.Base;
using Domain.Entities;

namespace Domain.Entites
{
    public class Color : BaseEntity
    {
        public Color()
        {
            Cars = new HashSet<Car>();
        }
        public string Name { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
