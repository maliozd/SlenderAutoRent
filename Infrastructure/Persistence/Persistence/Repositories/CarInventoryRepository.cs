using Application.Repositories;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.Base;

namespace Persistence.Repositories
{
    public class CarInventoryRepository : BaseRepository<CarInventory>, ICarInventoryRepository
    {
        public CarInventoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
