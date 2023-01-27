using System.ComponentModel.DataAnnotations;

namespace Domain.Entites.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }


}
