using Application.Repositories;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.Base;

namespace Persistence.Repositories
{
    public class TransmissionRepository : BaseRepository<Transmission>, ITransmissionRepository
    {
        public TransmissionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
