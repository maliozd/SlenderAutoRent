using Application.Repositories;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.Base;

namespace Persistence.Repositories
{
    public class BodyTypeRepository : BaseRepository<BodyType>, IBodyTypeRepository
    {
        public BodyTypeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
