using Application.Repositories;
using Domain.Entites.Identity;
using Persistence.Context;
using Persistence.Repositories.Base;

namespace Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }


    }
}
