using Application.Repositories;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.Base;

namespace Persistence.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
