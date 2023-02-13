using Domain.Entites.Base;

namespace Domain.Entities;

public partial class Customer : BaseEntity
{
    public Customer()
    {
        Rentals = new HashSet<Rental>();
    }
    public int UserId { get; set; }




    public virtual ICollection<Rental> Rentals { get; }

}
