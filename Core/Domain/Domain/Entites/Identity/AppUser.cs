using Microsoft.AspNetCore.Identity;

namespace Domain.Entites.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime RegistrationDate { get; set; }

    }
}
