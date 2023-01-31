using Domain.Entites.Base;

namespace Domain.Entities;

public partial class Customer : BaseEntity
{
    public Customer()
    {
        Rentals = new HashSet<Rental>();
    }
    public string Name { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime RegistrationDate { get; set; }

    public string Address { get; set; } = null!;

    public virtual ICollection<Rental> Rentals { get; }

}
