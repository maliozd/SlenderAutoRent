using Application.Repositories.Base;
using Domain.Entites.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.Context;
using System.Linq.Expressions;

namespace Persistence.Repositories.Base
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry entry = await Table.AddAsync(entity);
            return entry.State == EntityState.Added;
        }

        public bool Delete(T entity)
        {
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            T entityToDelete = await Table.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entityToDelete != null)
            {
                EntityEntry entry = Table.Remove(entityToDelete);
                return entry.State == EntityState.Deleted;
            }
            return false;
        }

        public IQueryable<T> GetAll()
        {
            return Table.AsQueryable();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var data = await Table.FindAsync(id);
            if (data != null)
                return data;

            throw new Exception("Entity can't be found");

        }

        public async Task<ICollection<T>> GetMultipleByFilter(Expression<Func<T, bool>> expression)
        {
            var data = await Table.Where(expression).ToListAsync();
            return data;
        }

        public async Task<T> GetOneByFilter(Expression<Func<T, bool>> expression)
        {
            var data = await Table.Where(expression).FirstOrDefaultAsync();
            if (data != null)
            {
                return data;
            }
            throw new Exception("There is no entity with this expression");
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public bool Update(T entity)
        {
            EntityEntry entry = Table.Update(entity);
            return entry.State == EntityState.Modified;
        }
    }
}
