using Domain.Entites.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Repositories.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
        Task<ICollection<T>> GetMultipleByFilter(Expression<Func<T, bool>> expression);
        Task<T> GetOneByFilter(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(Guid id);
        Task<bool> AddAsync(T entity);
        Task<bool> DeleteByIdAsync(Guid id);
        bool Delete(T entity);
        bool Update(T entity);
        Task<int> SaveAsync();
    }
}
