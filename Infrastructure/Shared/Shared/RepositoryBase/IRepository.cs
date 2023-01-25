using Shared.EntityBase.BaseEntity;
using System.Linq.Expressions;

namespace Shared.RepositoryBase
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
        Task<ICollection<T>> GetMultipleByFilter(Expression<Func<T, bool>> expression);
        Task<T> GetOneByFilter(Expression<Func<T, bool>> expression);
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<bool> AddAsync(T entity);
        Task<bool> DeleteByIdAsync(Guid id);
        Task<bool> Update(T entity);
        Task<int> SaveAsync();
    }
}
