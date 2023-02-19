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
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> AddAsync(T entity);
        Task<bool> DeleteByIdAsync(int id);
        bool Delete(T entity);
        bool Update(T entity);
        Task<int> SaveAsync();
    }
}
