using System.ComponentModel.DataAnnotations;

namespace Domain.Entites.Base
{
    public abstract class BaseEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<Guid>
    {
    }
}
